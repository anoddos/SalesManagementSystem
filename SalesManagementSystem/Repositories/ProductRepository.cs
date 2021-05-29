using System.Collections.Generic;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;

namespace SalesManagementSystem.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        private SalesDbContext _dbContext;
        public ProductRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public int Create(Product product)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> Read()
        {
            throw new System.NotImplementedException();
        }

        public int Update(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}