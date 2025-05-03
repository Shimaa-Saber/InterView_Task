
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InterView_Task.Models
{
    public class dbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<InventoryTransactions> Transactions { get; set; }
       
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryTransactions>()
                .HasOne(t => t.Source)
                .WithMany(w => w.SourceTransactions)
                .HasForeignKey(t => t.SourceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InventoryTransactions>()
                .HasOne(t => t.Destination)
                .WithMany(w => w.DestinationTransactions)
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

    }
}

