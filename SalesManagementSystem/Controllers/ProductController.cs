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
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _repository;

        public ProductController(ILogger<ProductController> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public int Create(Product product)
        {
            return _repository.Create(product);
        }
        
        [HttpPut]
        public int Update(long id, Product product)
        {
            return _repository.Update(product);
        }


        [HttpGet]
        public IEnumerable<Product> Read()
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
