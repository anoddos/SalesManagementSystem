using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystemDB.Models
{
    public partial class Product
    {
#nullable disable
        public long Id { get; set; }
        
        public String Name { get; set; }
        
        public Double Price { get; set; }
        
        public String Code { get; set; }
    }
}