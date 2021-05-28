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
    public class ConsultantController : ControllerBase
    {
        private readonly ILogger<ConsultantController> _logger;
        private readonly IConsultantRepositoy _repository;

        public ConsultantController(ILogger<ConsultantController> logger, IConsultantRepositoy repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public int Create(Consultant consultant)
        {
            
            return _repository.Create(consultant);
        }

        [HttpPut]
        public int Update(Consultant consultant)
        {
            return _repository.Update(consultant);
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
