
using Microsoft.AspNetCore.Identity;
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


            modelBuilder.Entity<ApplicationRole>().HasData(
               new ApplicationRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
               new ApplicationRole { Id = "2", Name = "User", NormalizedName = "USER" }
             
           );

            var adminUserId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = adminUserId,
                    UserName = "AdminShimaa",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "shimaasaber224@gmail.com",
                    NormalizedEmail = "SHIMAASABER224@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@1234"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                   
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                }
            );

        }

    }
}

