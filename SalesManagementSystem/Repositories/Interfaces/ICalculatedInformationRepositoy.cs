using System;
using System.Collections.Generic;
using SalesManagementSystem.Models.CalculatedInformationModels;

namespace SalesManagementSystem.Repositories.Interfaces
{
    public interface ICalculatedInformationRepositoy
    {
        IEnumerable<SalesOfConsultants> GetSalesOfConsultants(DateTime startDate, DateTime endDate);
        IEnumerable<SalesWithinPriceRange> GetSalesWithinPriceRange(long startPrice, DateTime endDate, DateTime startDate, DateTime dateTime);
        IEnumerable<ProductSellers> GetProductSellers(DateTime startDate, DateTime endDate, int minUnit, string code);
        IEnumerable<SumOfConsultantSales> GetSumOfConsultantSales(DateTime startDate, DateTime endDate);
    }
}