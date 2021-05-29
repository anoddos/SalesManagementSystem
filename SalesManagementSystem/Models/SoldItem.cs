using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalesManagementSystem.Models
{
    public class SoldItem
    {
        [JsonIgnore]
        public long Id { get; set; }
        
        [Required]
        public int Unit { get; set; }
    }
}