using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data.Repository
{
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository
    {
        public CustomerRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customers>> GetCustomersByAgeAsync(int age)
        {
            return await _dbSet.Where(c => c.Age == age).ToListAsync();
        }

        public async Task<IEnumerable<Customers>> GetActiveCustomersAsync()
        {
            return await _dbSet.Where(c => c.IsActive && !c.IsDeleted).ToListAsync();
        }
    }
}
