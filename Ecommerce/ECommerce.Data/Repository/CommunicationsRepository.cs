using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data.Repository
{
    public class CommunicationsRepository : GenericRepository<Communications>, ICommunicationsRepository
    {
        public CommunicationsRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Communications>> GetCommunicationsByCustomerIdAsync(int customerId)
        {
            return await _dbSet.Where(c => c.CustomerId == customerId).ToListAsync();
        }

        public async Task<IEnumerable<Communications>> GetActiveCommunicationsAsync()
        {
            return await _dbSet.Where(c => c.IsActive && !c.IsDeleted).ToListAsync();
        }
    }
}
