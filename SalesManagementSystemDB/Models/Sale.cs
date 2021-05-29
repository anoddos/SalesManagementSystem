using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystemDB.Models
{
    public partial class Sale
    {
#nullable disable
        public int Id { get; set; }
        
        public DateTime TimeStamp { get; set; }

        public Consultant Consultant { get; set; }
        
        public ICollection<SoldItem> SoldProduct { get; set; }
    }
}