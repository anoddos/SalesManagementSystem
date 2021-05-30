﻿using System;
using System.Collections.Generic;
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
        public ActionResult Create([FromBody]Product product)
        {
            return _repository.Create(product)? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Update(long id, [FromBody]Product product)
        {
            return _repository.Update(product) ? Ok() : BadRequest();
        }


        [HttpGet]
        public IEnumerable<Product> Read()
        {
            return _repository.Read();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Int64 id)
        {
            return _repository.Delete(id) ? Ok() : BadRequest();
        }
    }

}
