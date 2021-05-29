using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<SalesWithinPriceRange> GetSalesWithinPriceRange(long startPrice, DateTime endDate, DateTime startDate, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductSellers> GetProductSellers(DateTime startDate, DateTime endDate, int minUnit, string code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SumOfConsultantSales> GetSumOfConsultantSales(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}