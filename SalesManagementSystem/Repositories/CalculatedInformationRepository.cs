using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using SalesManagementSystem.Models;
using SalesManagementSystem.Models.CalculatedInformationModels;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;

namespace SalesManagementSystem.Repositories
{
    public class CalculatedInformationRepository : ICalculatedInformationRepositoy
    {
        private SalesDbContext _dbContext;
        public CalculatedInformationRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IEnumerable<SalesOfConsultants> GetSalesOfConsultants(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Sale.Where(x => x.TimeStamp > startDate && x.TimeStamp < endDate).Select(x => new SalesOfConsultants()
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
                                              x.SoldProducts.Any(xx => xx.Product.Price > startPrice && xx.Product.Price < endPrice)).Select(x => new SalesWithinPriceRange()
            {
                    SaleId = x.Id,
                    TimeStamp = x.TimeStamp,
                    ConsultantId = x.ConsultantId,
                    ConsultantName = x.Consultant.Name + " " + x.Consultant.LastName,
                    PersonalId = x.Consultant.PersonalId,
                    ProductCount = x.SoldProducts.Count(xx => xx.Product.Price > startPrice && xx.Product.Price < endPrice)
            });
        }

        public IEnumerable<ProductSellers> GetProductSellers(DateTime startDate, DateTime endDate, int minUnit, string code)
        {
            var validProducts = _dbContext.Product.Where(x => code == null || x.Code == code);
            var query = _dbContext.Sale
                .Join(_dbContext.Consultant, sale => sale.ConsultantId, consultant => consultant.Id,
                    (sale, consultant) => new
                    {
                        SaleId = sale.Id, ConsultantId = consultant.Id, ConsultantName = consultant.Name,
                        PersonalId = consultant.PersonalId, BirthDate = consultant.BirthDate
                    });
                //.Join(_dbContext.SoldItem, sale => sale.SaleId, soldItem => soldItem.)


            return null;
        }

        public IEnumerable<SumOfConsultantSales> GetSumOfConsultantSales(DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsultantsBestSales> GetConsultantsBestSales(DateTime? startDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

    }
}