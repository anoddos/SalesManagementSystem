using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class SoldItem
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public int Unit { get; set; }
    }
}