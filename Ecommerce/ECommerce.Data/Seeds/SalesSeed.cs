using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;



namespace ECommerce.Data.Seeds
{
    public static class SalesSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    Id = 1,
                    CustomerId = 1,
                    ProductId = 1,
                    SaleDate = DateTime.UtcNow,
                    Quantity = 2,
                    TotalAmount = 3000.00m
                },
                new Sales
                {
                    Id = 2,
                    CustomerId = 2,
                    ProductId = 2,
                    SaleDate = DateTime.UtcNow,
                    Quantity = 1,
                    TotalAmount = 900.00m
                },
                new Sales
                {
                    Id = 3,
                    CustomerId = 3,
                    ProductId = 3,
                    SaleDate = DateTime.UtcNow,
                    Quantity = 3,
                    TotalAmount = 600.00m
                },
                new Sales
                {
                    Id = 4,
                    CustomerId = 4,
                    ProductId = 4,
                    SaleDate = DateTime.UtcNow,
                    Quantity = 1,
                    TotalAmount = 250.00m
                },
                new Sales
                {
                    Id = 5,
                    CustomerId = 5,
                    ProductId = 5,
                    SaleDate = DateTime.UtcNow,
                    Quantity = 2,
                    TotalAmount = 1000.00m
                }
            );
        }
    }
}

