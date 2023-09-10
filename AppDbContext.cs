using efCoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace efCoreApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd(); // Configure the Id property as an identity column

            // Other entity configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
