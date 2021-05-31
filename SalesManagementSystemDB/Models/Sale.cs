using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystemDB.Models
{
    public class Sale
    {
#nullable disable
        public long Id { get; set; }
        public long ConsultantId { get; set; }
        
        public DateTime TimeStamp { get; set; }

        public Consultant Consultant { get; set; }
        
        public ICollection<SoldItem> SoldProducts { get; set; }
    }
}