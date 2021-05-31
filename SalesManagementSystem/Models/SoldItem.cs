using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SalesManagementSystem.Models
{
    public class SoldItem
    {
        [Required]
        public long ProductId { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public long Unit { get; set; }
    }
}