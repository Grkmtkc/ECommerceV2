using ECommerce.Core.Entities;

namespace ECommerce.Core.Repositories
{
    public interface ICommunicationsRepository : IGenericRepository<Communications>
    {
        Task<IEnumerable<Communications>> GetCommunicationsByCustomerIdAsync(int customerId);
        Task<IEnumerable<Communications>> GetActiveCommunicationsAsync();
    }
}
