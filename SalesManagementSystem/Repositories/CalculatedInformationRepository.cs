using System;
using System.Collections.Generic;
using SalesManagementSystem.Models.CalculatedInformationModels;
using SalesManagementSystem.Repositories.Interfaces;

namespace SalesManagementSystem.Repositories
{
    public class CalculatedInformationRepository : ICalculatedInformationRepositoy
    {
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