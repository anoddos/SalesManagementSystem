using Microsoft.EntityFrameworkCore;
using SalesManagementSystemDB.Models;

namespace SalesManagementSystemDB.DataAccess
{
    public class SalesDbContext : DbContext
    {

        public SalesDbContext(DbContextOptions<SalesDbContext> options): base(options) { }
        
        public virtual DbSet<Gender> Gender { get; set; }
        
        public virtual DbSet<Consultant> Consultant { get; set; }
        
        public virtual DbSet<Product> Product { get; set; }
        
        public virtual DbSet<SoldItem> SoldItem { get; set; }
        
        public virtual DbSet<Sale> Sale { get; set; }
        
    }
}