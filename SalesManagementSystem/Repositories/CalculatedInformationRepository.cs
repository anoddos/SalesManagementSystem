using System;
using System.Collections.Generic;
using System.Linq;
using SalesManagementSystem.Models.CalculatedInformationModels;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;
using db = SalesManagementSystemDB.Models;

namespace SalesManagementSystem.Repositories
{
    public class CalculatedInformationRepository : ICalculatedInformationRepositoy
    {
        private readonly SalesDbContext _dbContext;
        public CalculatedInformationRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<SalesOfConsultants> GetSalesOfConsultants(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Sale.Where(x => x.TimeStamp > startDate && x.TimeStamp < endDate)
                .Select(x => new SalesOfConsultants()
                {
                    SaleId = x.Id,
                    TimeStamp = x.TimeStamp,
                    ConsultantId = x.ConsultantId,
                    ConsultantName = x.Consultant.Name + " " + x.Consultant.LastName,
                    PersonalId = x.Consultant.PersonalId,
                    TotalQuantity = x.SoldProducts.Sum(xx => xx.Unit),
                    TotalPrice = x.SoldProducts.Sum(xx => xx.Unit * xx.Product.Price)
                });

        }

        public IEnumerable<SalesWithinPriceRange> GetSalesWithinPriceRange(long startPrice, long endPrice, DateTime startDate, DateTime endDate)
        {

            return _dbContext.Sale.Where(x => x.TimeStamp > startDate && x.TimeStamp < endDate &&
                                              x.SoldProducts.Any(xx =>
                                                  xx.Product.Price > startPrice && xx.Product.Price < endPrice))
                .Select(x => new SalesWithinPriceRange()
                {
                        SaleId = x.Id,
                        TimeStamp = x.TimeStamp,
                        ConsultantId = x.ConsultantId,
                        ConsultantName = x.Consultant.Name + " " + x.Consultant.LastName,
                        PersonalId = x.Consultant.PersonalId,
                        ProductCount = x.SoldProducts.Count(xx => xx.Product.Price > startPrice && xx.Product.Price < endPrice)
                });
        }

        public IEnumerable<ProductSellers> GetProductSellers(DateTime startDate, DateTime endDate, int minUnit,
            string code)
        {
            var productSellers = from sale in _dbContext.Sale
                join consultant in _dbContext.Consultant on sale.ConsultantId equals consultant.Id
                join soldItem in _dbContext.SoldItem on sale.Id equals soldItem.SaleId
                join product in _dbContext.Product on soldItem.ProductId equals product.Id
                where sale.TimeStamp > startDate && sale.TimeStamp < endDate
                group new {product, consultant, soldItem} by new
                {
                    consultantId = consultant.Id, product.Code, name = consultant.Name + " " + consultant.LastName,
                    consultant.BirthDate, consultant.PersonalId
                } into grp
                select new ProductSellers()
                {
                    ConsultantId = grp.Key.consultantId,
                    ConsultantName = grp.Key.name,
                    PersonalId = grp.Key.PersonalId,
                    BirthDate = grp.Key.BirthDate,
                    ProductCode = grp.Key.Code,
                    SalesCount = grp.AsEnumerable().Select(x => x.soldItem.Unit).Sum()
                };

            return productSellers.Where(x => x.SalesCount >= minUnit && (x.ProductCode == code || code == null));
        }

        public IEnumerable<SumOfConsultantSales> GetSumOfConsultantSales(DateTime? startDate, DateTime? endDate)
        {
            IDictionary<long, long> subConsultantSums = GetSumOfSubConsultantSales();

            var result = from consultant in _dbContext.Consultant
                join sale in _dbContext.Sale on consultant.Id equals sale.ConsultantId into gj
                from subSale in gj.DefaultIfEmpty()
                group new {consultant} by new
                {
                    consultantId = consultant.Id,
                    name = consultant.Name + " " + consultant.LastName,
                    consultant.BirthDate,
                    consultant.PersonalId,
                } into grp
                select new SumOfConsultantSales()
                {
                    ConsultantId = grp.Key.consultantId,
                    ConsultantName = grp.Key.name,
                    BirthDate = grp.Key.BirthDate,
                    PersonalId = grp.Key.PersonalId,
                    SoldByConsultant = grp.Count(),
                    SoldBySubConsultant = subConsultantSums[grp.Key.consultantId]
                };
            
            return result;
        }


        private long GetSubConsultantsRecursive(long recommendatorId)
        {
            var recommended = _dbContext.Consultant.Where(x => x.RecommendatorId == recommendatorId);
            foreach (var consultant in recommended)
            {
                var res = GetSubConsultantsRecursive(consultant.Id);
                return res + _dbContext.Sale.Count(x => x.ConsultantId == recommendatorId);
            }
            return _dbContext.Sale.Count(x => x.ConsultantId == recommendatorId);
        }

        private IDictionary <long, long> GetSumOfSubConsultantSales()
        {
            IDictionary<long, long> subSalesDictionary = new Dictionary<long, long>();
            var consultantIds = _dbContext.Consultant.Select(x => x.Id);

            foreach (var consultantId in consultantIds)
            {
                var count = GetSubConsultantsRecursive(consultantId);
                subSalesDictionary.Add(new KeyValuePair<long, long>(consultantId, count));
            }
            return subSalesDictionary;
        }
       public IEnumerable<ConsultantsBestSales> GetConsultantsBestSales(DateTime? startDate, DateTime? endDate)
        {
            var productSellers = from sale in _dbContext.Sale
                join consultant in _dbContext.Consultant on sale.ConsultantId equals consultant.Id
                join soldItem in _dbContext.SoldItem on sale.Id equals soldItem.SaleId
                join product in _dbContext.Product on soldItem.ProductId equals product.Id
                where sale.TimeStamp > startDate && sale.TimeStamp < endDate
                group new {product, consultant, soldItem} by new
                {
                    consultantId = consultant.Id, product.Code, name = consultant.Name + " " + consultant.LastName,
                    consultant.BirthDate, consultant.PersonalId, productName = product.Name
                }into grp
                select new
                {
                    grp.Key.consultantId,
                    grp.Key.name,
                    grp.Key.PersonalId,
                    grp.Key.BirthDate,
                    grp.Key.Code,
                    grp.Key.productName,
                    ProductCount = grp.Sum(x=>x.soldItem.Unit), 
                    Profit = grp.Sum(x=> x.soldItem.Unit * x.product.Price)
                };

            var mostProfitable = productSellers.AsEnumerable().GroupBy(x => x.consultantId,
                (_, g) => g.OrderByDescending(x => x.Profit).FirstOrDefault());
            var mostFrequent = productSellers.AsEnumerable().GroupBy(x => x.consultantId,
                (_, g) => g.OrderByDescending(x => x.ProductCount).FirstOrDefault());

            return mostProfitable.Select(x => new ConsultantsBestSales()
            {
                ConsultantId = x.consultantId,
                ConsultantName = x.name,
                PersonalId = x.PersonalId,
                BirthDate = x.BirthDate,
                FrequentProductCode = mostFrequent.Single(xx => xx.consultantId == x.consultantId).Code,
                FrequentProductCount = mostFrequent.Single(xx => xx.consultantId == x.consultantId).ProductCount,
                FrequentProductName = mostFrequent.Single(xx => xx.consultantId == x.consultantId).productName,
                ProfitableProductCode = x.Code,
                ProfitableProductCount = x.ProductCount,
                ProfitableProductName = x.productName
            });
        }
    }
}