using System;

namespace SalesManagementSystemDB.Models
{
    public  class Consultant
    {
#nullable disable
        public long Id { get; set; }
        
        public String Name { get; set; }
        
        public String LastName { get; set; }
        
        public long PersonalId { get; set; }
        
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

#nullable enable
        public long? RecommendatorId { get; set; }

        public Consultant Recommendator { get; set; }


    }
}