using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data.Seeds
{
    public static class ProductsSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    Id = 1,
                    ProductName = "Laptop",
                    Description = "High-performance laptop",
                    Price = 1500.00m,
                    StockQuantity = 50,
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Products
                {
                    Id = 2,
                    ProductName = "Smartphone",
                    Description = "Latest model smartphone",
                    Price = 900.00m,
                    StockQuantity = 100,
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Products
                {
                    Id = 3,
                    ProductName = "Headphones",
                    Description = "Noise-cancelling headphones",
                    Price = 200.00m,
                    StockQuantity = 150,
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Products
                {
                    Id = 4,
                    ProductName = "Smartwatch",
                    Description = "Waterproof smartwatch",
                    Price = 250.00m,
                    StockQuantity = 75,
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Products
                {
                    Id = 5,
                    ProductName = "Gaming Console",
                    Description = "Next-gen gaming console",
                    Price = 500.00m,
                    StockQuantity = 30,
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                }
            );
        }
    }
}
