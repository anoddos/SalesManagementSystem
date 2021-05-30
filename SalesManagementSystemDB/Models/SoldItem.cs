namespace SalesManagementSystemDB.Models
{
    public class SoldItem
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        
        public Product Product { get; set; }
        
        public long Unit { get; set; }
    }
}