using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models
{
    public class Consultant
    {
        [JsonIgnore]
        public long Id { get; set; }
        
        [Required]
        public String Name { get; set; }
        
        [Required]
        public String LastName { get; set; }
        
        [Required]
        public long PersonalId { get; set; }
        
        [Required]
        public long GenderId { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        public long RecommendatorId { get; set; }
    }
}
