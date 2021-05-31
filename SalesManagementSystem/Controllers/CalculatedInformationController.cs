using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesManagementSystem.Models.CalculatedInformationModels;
using SalesManagementSystem.Repositories.Interfaces;

namespace SalesManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatedInformationController : ControllerBase
    {
        private readonly ILogger <CalculatedInformationController> _logger;
        private readonly ICalculatedInformationRepositoy _repository;

        public CalculatedInformationController(ILogger <CalculatedInformationController> logger, ICalculatedInformationRepositoy repository)
        {
            _logger = logger;
            _repository = repository;
        }
        
        [HttpGet("GetSalesOfConsultants")]
        public IEnumerable<SalesOfConsultants> GetSalesOfConsultants(DateTime startDate, DateTime endDate)
        {
            return _repository.GetSalesOfConsultants(startDate, endDate);
        } 
        [HttpGet("GetSalesWithinPriceRange")]
        public IEnumerable<SalesWithinPriceRange> GetSalesWithinPriceRange(long startPrice, long endPrice, DateTime startDate,DateTime endDate)
        {
            return _repository.GetSalesWithinPriceRange(startPrice, endPrice, startDate, endDate);
        } 
        [HttpGet("GetProductSellers")]
        public IEnumerable<ProductSellers> GetProductSellers(DateTime startDate,DateTime endDate, int minUnit, String code)
        {
            return _repository.GetProductSellers(startDate, endDate, minUnit, code);
        }

        [HttpGet("GetSumOfConsultantSales")] 
        public IEnumerable<SumOfConsultantSales> GetSumOfConsultantSales(DateTime startDate,DateTime endDate)
        {
            return _repository.GetSumOfConsultantSales(startDate, endDate);
        }
        [HttpGet("GetConsultantsBestSales")] 
        public IEnumerable<ConsultantsBestSales> GetConsultantsBestSales(DateTime? startDate, DateTime? endDate)
        {
            return _repository.GetConsultantsBestSales(startDate, endDate);
        }

    }
}