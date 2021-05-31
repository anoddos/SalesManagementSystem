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
        private readonly ISaleRepository _repository;

        public SaleController(ISaleRepository repository )
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult Create([FromBody]Sale sale)
        {
            return _repository.Create(sale) ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Update(long id, [FromBody]Sale sale)
        {
            sale.Id = id;
            return _repository.Update(sale) ? Ok() : BadRequest();
        }

        [HttpGet]
        public IEnumerable<Sale> Read()
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
