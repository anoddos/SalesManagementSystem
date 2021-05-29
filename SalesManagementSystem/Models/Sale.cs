using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalesManagementSystem.Models
{
    public class Sale
    {
        [JsonIgnore]
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
