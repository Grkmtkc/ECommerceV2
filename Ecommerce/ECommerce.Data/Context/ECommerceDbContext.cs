using ECommerce.Core.Entities;
using ECommerce.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace ECommerce.Data.Context
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Communications> Communications { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>()
           .HasOne(a => a.Customer)
           .WithMany(c => c.Addresses)
           .HasForeignKey(a => a.CustomerId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            CustomersSeed.Seed(modelBuilder);
            AddressesSeed.Seed(modelBuilder);
            CommunicationsSeed.Seed(modelBuilder);
            ProductsSeed.Seed(modelBuilder);
            SalesSeed.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

    }
}
