using ECommerce.Core.Entities;

namespace ECommerce.Core.Repositories
{
    public interface ICommunicationRepository : IGenericRepository<Communications>
    {
        Task<IEnumerable<Communications>> GetCommunicationsByCustomerIdAsync(int customerId);
        Task<IEnumerable<Communications>> GetActiveCommunicationsAsync();
    }
}
