using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCart>().HasMany(sc => sc.Products);

            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Product>().Property(p => p.Pieces).IsRequired();
            modelBuilder.Entity<Product>().Ignore(p => p.Total);

            modelBuilder.Entity<ShoppingCart>().Property(sc => sc.Id).IsRequired();
            modelBuilder.Entity<ShoppingCart>().Property(sc => sc.Description).IsRequired().HasMaxLength(30);

            modelBuilder.Entity<ShoppingCart>().Property(sc => sc.Date).IsRequired();
            modelBuilder.Entity<ShoppingCart>().Ignore(sc => sc.Total);
        }
    }
}
