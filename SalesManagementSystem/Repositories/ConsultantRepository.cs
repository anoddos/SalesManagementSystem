using System.Collections.Generic;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;

namespace SalesManagementSystem.Repositories
{
    public class ConsultantRepository : IConsultantRepositoy
    {

        private SalesDbContext _dbContext;
        public ConsultantRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public int Create(Consultant consultant)
        {
            throw new System.NotImplementedException();
        }

        public int Update(Consultant consultant)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Sale> Read()
        {
            throw new System.NotImplementedException();
        }

        public int Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}