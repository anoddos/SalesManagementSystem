using System.Collections.Generic;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;
using db = SalesManagementSystemDB.Models;
using System.Linq;

namespace SalesManagementSystem.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SalesDbContext _dbContext;
        public SaleRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(Sale sale)
        {
            ValidateChanges(sale);
            db.Sale dbSale = new db.Sale()
            {
                TimeStamp = sale.TimeStamp,
                ConsultantId = sale.ConsultantId,
                SoldProducts = sale.Products.Select(x => new db.SoldItem()
                {
                    ProductId = x.ProductId,
                    Unit = x.Unit,
                    SaleId = sale.Id
                }).ToList()
            };

            _dbContext.Add(dbSale);
            return _dbContext.SaveChanges() > 0;
        }

      
        public bool Delete(long id)
        {
            var toBeDeleted = _dbContext.Sale.SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
            {
                DeleteSoldItems(id);
                _dbContext.Remove(toBeDeleted);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<Sale> Read()
        {
            var dbSales = _dbContext.Sale.Select(x => new Sale()
            {
                TimeStamp = x.TimeStamp,
                ConsultantId = x.ConsultantId,
                Products = x.SoldProducts.Select(xx => new SoldItem()
                {
                    ProductId = xx.ProductId,
                    Unit = xx.Unit
                }).ToList()
            }).ToList();

            return dbSales;
        }

        public bool Update(Sale sale)
        {
            ValidateChanges(sale);
            db.Sale dbSale = _dbContext.Sale.SingleOrDefault(x => x.Id == sale.Id);
            if (dbSale != null)
            {
                DeleteSoldItems(sale.Id);
                dbSale.TimeStamp = sale.TimeStamp;
                dbSale.ConsultantId = sale.ConsultantId;
                dbSale.SoldProducts = sale.Products.Select(x => new db.SoldItem()
                {
                    ProductId = x.ProductId,
                    Unit = x.Unit,
                    SaleId = sale.Id
                }).ToList();

                _dbContext.Update(dbSale);
            }

            return _dbContext.SaveChanges() > 0;
        }

        private void DeleteSoldItems(long saleId)
        {
            var toBeDeleted = _dbContext.SoldItem.Where(x => x.SaleId == saleId);
            _dbContext.RemoveRange(toBeDeleted);
            _dbContext.SaveChanges();
        }
        
        private void ValidateChanges(Sale sale)
        {
            if (!_dbContext.Consultant.Any(x => x.Id == sale.ConsultantId))
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel.Message = "Consultant doesn't exists.";
                throw new MyException(errorModel, null);
            }

            foreach (var product in sale.Products)
            {
                if (!_dbContext.Product.Any(x => x.Id == product.ProductId))
                {
                    ErrorModel errorModel = new ErrorModel();
                    errorModel.Message = $"Product: {product.ProductId} doesn't exists.";
                    throw new MyException(errorModel, null);
                }
            }
        }
        
    }
}