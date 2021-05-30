using System;
using System.Collections.Generic;
using SalesManagementSystem.Models.CalculatedInformationModels;

namespace SalesManagementSystem.Repositories.Interfaces
{
    public interface ICalculatedInformationRepositoy
    {
        IEnumerable<SalesOfConsultants> GetSalesOfConsultants(DateTime startDate, DateTime endDate);
        IEnumerable<SalesWithinPriceRange> GetSalesWithinPriceRange(long startPrice, long endPrice, DateTime startDate, DateTime endDate);
        IEnumerable<ProductSellers> GetProductSellers(DateTime startDate, DateTime endDate, int minUnit, string? code);
        IEnumerable<SumOfConsultantSales> GetSumOfConsultantSales(DateTime? startDate, DateTime? endDate);
        IEnumerable<ConsultantsBestSales> GetConsultantsBestSales(DateTime? startDate, DateTime? endDate);
    }
}