using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystemDB.Models
{
    public class SoldItem
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long SaleId { get; set; }
        public Product Product { get; set; }

        [Range(1, int.MaxValue)]
        public long Unit { get; set; }
        public Sale Sale { get; set; }
    }
}