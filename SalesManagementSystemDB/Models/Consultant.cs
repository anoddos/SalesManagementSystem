using System;

namespace SalesManagementSystemDB.Models
{
    public partial class Consultant
    {
#nullable disable
        public int Id { get; set; }
        
        public Gender Gender { get; set; }
        
        public String Name { get; set; }
        
        public String LastName { get; set; }
        
        public long PersonalId { get; set; }
        
        public DateTime BirthDate { get; set; }
#nullable enable
        public Consultant Recommendator { get; set; }
    }
}