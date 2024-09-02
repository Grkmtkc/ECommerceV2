using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data.Seeds
{
    public static class CustomersSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasData(
                new Customers
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 30,
                    Birthday = new DateTime(1994, 5, 15),
                    RegistrationDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Customers
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Age = 28,
                    Birthday = new DateTime(1996, 7, 22),
                    RegistrationDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Customers
                {
                    Id = 3,
                    FirstName = "Robert",
                    LastName = "Johnson",
                    Age = 45,
                    Birthday = new DateTime(1979, 3, 5),
                    RegistrationDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Customers
                {
                    Id = 4,
                    FirstName = "Emily",
                    LastName = "Davis",
                    Age = 35,
                    Birthday = new DateTime(1989, 10, 12),
                    RegistrationDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                new Customers
                {
                    Id = 5,
                    FirstName = "Michael",
                    LastName = "Wilson",
                    Age = 40,
                    Birthday = new DateTime(1984, 12, 1),
                    RegistrationDate = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                }
            );
        }
    }
}
