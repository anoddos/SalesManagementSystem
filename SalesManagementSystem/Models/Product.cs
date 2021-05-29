using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalesManagementSystem.Models
{
    public class Product
    {
        [JsonIgnore]
        public long Id { get; set; }
        
        [Required]
        public String Name { get; set; }
        
        [Required]
        public Double Price { get; set; }
        
        [Required]
        public String Code { get; set; }

    }
}
