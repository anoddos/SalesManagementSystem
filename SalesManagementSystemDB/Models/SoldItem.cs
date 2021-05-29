namespace SalesManagementSystemDB.Models
{
    public partial class SoldItem
    {
        public long Id { get; set; }
        
        public Product Product { get; set; }
        
        public long Unit { get; set; }
    }
}