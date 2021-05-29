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
        public int Create(Sale sale)
        {
            throw new System.NotImplementedException();
        }

        public int Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Sale> Read()
        {
            throw new System.NotImplementedException();
        }

        public int Update(Sale sale)
        {
            throw new System.NotImplementedException();
        }
    }
}