using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Seeds
{
    public static class AddressesSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>().HasData(
                new Addresses
                {
                    Id = 1,
                    CustomerId = 1,
                    Adress = "123 Elm Street",
                    City = "Springfield",
                    Country = "USA",
                    IsActive = true,
                    IsDeleted = false
                },
                new Addresses
                {
                    Id = 2,
                    CustomerId = 2,
                    Adress = "456 Oak Avenue",
                    City = "Shelbyville",
                    Country = "USA",
                    IsActive = true,
                    IsDeleted = false
                },
                new Addresses
                {
                    Id = 3,
                    CustomerId = 3,
                    Adress = "789 Maple Road",
                    City = "Capital City",
                    Country = "USA",
                    IsActive = true,
                    IsDeleted = false
                },
                new Addresses
                {
                    Id = 4,
                    CustomerId = 4,
                    Adress = "101 Pine Lane",
                    City = "Greenfield",
                    Country = "USA",
                    IsActive = true,
                    IsDeleted = false
                },
                new Addresses
                {
                    Id = 5,
                    CustomerId = 5,
                    Adress = "202 Birch Boulevard",
                    City = "Rivertown",
                    Country = "USA",
                    IsActive = true,
                    IsDeleted = false
                }
            );
        }
    }
}
