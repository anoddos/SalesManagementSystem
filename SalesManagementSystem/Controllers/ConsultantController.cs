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
        public ActionResult Create([FromBody]Consultant consultant)
        {
            if (consultant.RecommendatorId == 0)
            {
                consultant.RecommendatorId = null;
            }

            return _repository.Create(consultant) ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Update(long id, [FromBody]Consultant consultant)
        {
            consultant.Id = id;
            if (consultant.RecommendatorId == 0)
            {
                consultant.RecommendatorId = null;
            }

            return _repository.Update(consultant) ? Ok() : BadRequest(); 
        }

        [HttpGet]
        public IEnumerable<Consultant> Read()
        {
            return _repository.Read();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            return _repository.Delete(id) ? Ok() : BadRequest();
        }

    }
}
