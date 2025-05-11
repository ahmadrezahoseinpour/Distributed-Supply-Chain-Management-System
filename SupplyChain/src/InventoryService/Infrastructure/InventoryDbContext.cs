using InventoryService.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Infrastructure
{
    public class InventoryDbContext : DbContext
    {
        public DbSet<Inventory> MyProperty { get; set; }
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Inventory>()
                .Property(i => i.Quantity)
                .IsConcurrencyToken();
        }
    }
}
