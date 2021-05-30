﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using SalesManagementSystem.Models;
using SalesManagementSystem.Repositories.Interfaces;
using SalesManagementSystemDB.DataAccess;
using db = SalesManagementSystemDB.Models;

namespace SalesManagementSystem.Repositories
{
    public class ConsultantRepository : IConsultantRepositoy
    {

        private SalesDbContext _dbContext;
        public ConsultantRepository(SalesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Create(Consultant consultant)
        {
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
            db.Consultant dbConsultant = _dbContext.Consultant.SingleOrDefault(x => x.Id == consultant.Id);
            if (dbConsultant != null)
            {
                dbConsultant.BirthDate = consultant.BirthDate;
                dbConsultant.RecommendatorId = consultant.RecommendatorId;
                dbConsultant.GenderId = consultant.GenderId;
                dbConsultant.Name = consultant.Name;
                dbConsultant.LastName = consultant.LastName;
                _dbContext.Add(dbConsultant);
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
            var toBeDeleted = _dbContext.Consultant.SingleOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
            {
                _dbContext.Remove(toBeDeleted);
            }

            return _dbContext.SaveChanges() > 0;
        }
    }
}