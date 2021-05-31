using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;
using db = SalesManagementSystemDB.Models;

namespace SalesManagementSystem.Repositories
{
    public class ConsultantRepository : IConsultantRepository
    {

        private readonly SalesDbContext _dbContext;
        public ConsultantRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(Consultant consultant)
        {
            ValidateChanges(consultant, new List<ValidationOptions> 
            {
                    ValidationOptions.RecommendatorId,
                    ValidationOptions.Gender, 
                    ValidationOptions.PersonalId
            });
            var dbConsultant = new db.Consultant
            {
                Name = consultant.Name,
                LastName =  consultant.LastName,
                BirthDate = consultant.BirthDate,
                PersonalId = consultant.PersonalId,
                RecommendatorId = consultant.RecommendatorId,
                GenderId = consultant.GenderId
            };

            _dbContext.Add(dbConsultant);
            return _dbContext.SaveChanges() > 0;
        }

        

        public bool Update(Consultant consultant)
        {
            ValidateChanges(consultant, new List<ValidationOptions>
            {
                ValidationOptions.Gender, 
                ValidationOptions.RecommendatorId
            });
            var dbConsultant = _dbContext.Consultant.SingleOrDefault(x => x.Id == consultant.Id);
            if (dbConsultant != null)
            {
                dbConsultant.BirthDate = consultant.BirthDate;
                dbConsultant.RecommendatorId = consultant.RecommendatorId;
                dbConsultant.GenderId = consultant.GenderId;
                dbConsultant.Name = consultant.Name;
                dbConsultant.LastName = consultant.LastName;
                _dbContext.Update(dbConsultant);
            }

            return _dbContext.SaveChanges() > 0;
        }

        public IEnumerable<Consultant> Read()
        {
            var dbConsultants = _dbContext.Consultant.Select(x => new Consultant()
            {
               Name = x.Name,
               LastName = x.LastName,
               BirthDate = x.BirthDate,
               PersonalId = x.PersonalId,
               RecommendatorId = x.RecommendatorId,
               GenderId = x.GenderId
            }).ToList();

            return dbConsultants;
        }


        public bool Delete(long id)
        {
            if (_dbContext.Consultant.Any(x => x.RecommendatorId == id))
            {
                var errorModel = new ErrorModel {Message = "This Consultant is others recommender. you cant delete"};
                throw new MyException(errorModel, null);
            }
            
            var toBeDeleted = _dbContext.Consultant.SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
            {
                _dbContext.Remove(toBeDeleted);
            }
            return _dbContext.SaveChanges() > 0;
        }
        
        private void ValidateChanges(Consultant consultant, List<ValidationOptions> options )
        {
            if (options.Contains(ValidationOptions.RecommendatorId) && consultant.RecommendatorId != null && !_dbContext.Consultant.Any(x => x.Id == consultant.RecommendatorId))
            {
                var errorModel = new ErrorModel {Message = "RecomendatorId is not valid."};
                throw new MyException(errorModel, null);
            }
            if (options.Contains(ValidationOptions.RecommendatorId) && !_dbContext.Gender.Any(x => x.Id == consultant.GenderId))
            {
                var errorModel = new ErrorModel {Message = "GenderId is not valid."};
                throw new MyException(errorModel, null);
            }
            if (options.Contains(ValidationOptions.RecommendatorId) && _dbContext.Consultant.Any(x => x.PersonalId == consultant.PersonalId))
            {
                var errorModel = new ErrorModel {Message = "this personal Id is already registered."};
                throw new MyException(errorModel, null);
            }
        }


        private enum ValidationOptions
        {
            RecommendatorId,
            Gender,
            PersonalId
        }
    }
}