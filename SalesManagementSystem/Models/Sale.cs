using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public class Sale
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }
        
        [Required]
        public long ConsultantId { get; set; }
        
        [Required]
        public List<SoldItem> Products { get; set; }
    }
}
