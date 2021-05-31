using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;
using db = SalesManagementSystemDB.Models;

namespace SalesManagementSystem.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        private readonly SalesDbContext _dbContext;
        public ProductRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(Product product)
        {
            ValidateChanges(product);
            db.Product dbProduct = new db.Product
            {
                Name = product.Name,
                Code = product.Code,
                Price = product.Price
            };

            _dbContext.Add(dbProduct);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Product product)
        {
            db.Product dbProduct = _dbContext.Product.SingleOrDefault(x => x.Id == product.Id);
            if (dbProduct != null)
            {
                dbProduct.Name = product.Name;
                dbProduct.Code = product.Code;
                dbProduct.Price = product.Price;
                _dbContext.Update(dbProduct);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<Product> Read()
        {
            var dbProducts = _dbContext.Product.Select(x => new Product()
            {
                Name = x.Name,
                Code = x.Code,
                Price = x.Price
            }).ToList();

            return dbProducts;
        }

        public bool Delete(long id)
        {
            if (_dbContext.SoldItem.Any(x => x.ProductId == id))
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel.Message = "This ProductCode is already sold. you cant delete";
                throw new MyException(errorModel, null);
            }
            
            var toBeDeleted = _dbContext.Product.SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
            {
                _dbContext.Remove(toBeDeleted);
            }

            return _dbContext.SaveChanges() > 0;
        }
        
        private void ValidateChanges(Product product)
        {
            if (_dbContext.Product.Any(x => x.Code == product.Code))
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel.Message = "This ProductCode is already registered.";
                throw new MyException(errorModel, null);
            }
        }
    }
}