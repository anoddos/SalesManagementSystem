using System.Collections.Generic;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;

namespace SalesManagementSystem.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private SalesDbContext _dbContext;
        public SaleRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(Sale sale)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Sale> Read()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Sale sale)
        {
            throw new System.NotImplementedException();
        }
    }
}