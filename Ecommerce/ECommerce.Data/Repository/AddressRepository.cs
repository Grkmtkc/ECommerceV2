using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data.Repository
{
    public class AddressRepository : GenericRepository<Addresses>, IAddressRepository
    {
        public AddressRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Addresses>> GetAddressesByCustomerIdAsync(int customerId)
        {
            return await _dbSet.Where(a => a.CustomerId == customerId).ToListAsync();
        }

        public async Task<IEnumerable<Addresses>> GetActiveAddressesAsync()
        {
            return await _dbSet.Where(a => a.IsActive && !a.IsDeleted).ToListAsync();
        }
    }
}
