using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories.Interfaces;

namespace SalesManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly ISaleRepository _repository;

        public SaleController(ILogger<SaleController> logger, ISaleRepository repository )
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public int Create(Sale sale)
        {
            return _repository.Create(sale);
        }

        [HttpPut]
        public int Update(long id, Sale sale)
        {
            return _repository.Update(sale);
        }


        [HttpGet]
        public IEnumerable<Sale> Read()
        {
            var rng = new Random();
            return _repository.Read();
        }

        [HttpDelete]
        public int Delete(Int64 id)
        {
            return _repository.Delete(id);
        }
    }
}
