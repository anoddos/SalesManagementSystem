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
        public string Name { get; set; }
        
        [Required]
        [Range(0.01, int.MaxValue)]
        public double Price { get; set; }
        
        public string Code { get; set; }

    }
}
