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
    public class ConsultantRepository : IConsultantRepositoy
    {

        private readonly SalesDbContext _dbContext;
        public ConsultantRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(Consultant consultant)
        {
            ValidateChanges(consultant, new ValidationOptions(true,true, true));
            db.Consultant dbConsultant = new db.Consultant
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
            ValidateChanges(consultant, new ValidationOptions(true,false, true));
            db.Consultant dbConsultant = _dbContext.Consultant.SingleOrDefault(x => x.Id == consultant.Id);
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
                ErrorModel errorModel = new ErrorModel();
                errorModel.Message = "This Consultant is others recommender. you cant delete";
                throw new MyException(errorModel, null);
            }
            
            var toBeDeleted = _dbContext.Consultant.SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
            {
                _dbContext.Remove(toBeDeleted);
            }
            return _dbContext.SaveChanges() > 0;
        }
        
        private void ValidateChanges(Consultant consultant, ValidationOptions options )
        {
            if (options.RecommendatorId && consultant.RecommendatorId != null && !_dbContext.Consultant.Any(x => x.Id == consultant.RecommendatorId))
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel.Message = "RecomendatorId is not valid.";
                throw new MyException(errorModel, null);
            }
            if (options.Gender && !_dbContext.Gender.Any(x => x.Id == consultant.GenderId))
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel.Message = "GenderId is not valid.";
                throw new MyException(errorModel, null);
            }
            if (options.PersonalId && _dbContext.Consultant.Any(x => x.PersonalId == consultant.PersonalId))
            {
                ErrorModel errorModel = new ErrorModel();
                errorModel.Message = "this personal Id is already registered.";
                throw new MyException(errorModel, null);
            }
        }

        private readonly struct ValidationOptions
        { 
            public readonly bool RecommendatorId;
            public readonly bool Gender;
            public readonly bool PersonalId;

            public ValidationOptions(bool gender= false, bool personalId = false, bool recommendatorId = false)
            {
                RecommendatorId = recommendatorId;
                Gender = gender;
                PersonalId = personalId;

            }
        }
    }
}