using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data.Seeds
{
    public static class CommunicationsSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Communications>().HasData(
                new Communications
                {
                    Id = 1,
                    CustomerId = 1,
                    Email = "john.doe@example.com",
                    PhoneNumber = "+1-555-1234",
                    IsActive = true,
                    IsDeleted = false
                },
                new Communications
                {
                    Id = 2,
                    CustomerId = 2,
                    Email = "jane.smith@example.com",
                    PhoneNumber = "+1-555-5678",
                    IsActive = true,
                    IsDeleted = false
                },
                new Communications
                {
                    Id = 3,
                    CustomerId = 3,
                    Email = "robert.johnson@example.com",
                    PhoneNumber = "+1-555-9101",
                    IsActive = true,
                    IsDeleted = false
                },
                new Communications
                {
                    Id = 4,
                    CustomerId = 4,
                    Email = "emily.davis@example.com",
                    PhoneNumber = "+1-555-1122",
                    IsActive = true,
                    IsDeleted = false
                },
                new Communications
                {
                    Id = 5,
                    CustomerId = 5,
                    Email = "michael.wilson@example.com",
                    PhoneNumber = "+1-555-3344",
                    IsActive = true,
                    IsDeleted = false
                }
            );
        }
    }
}
