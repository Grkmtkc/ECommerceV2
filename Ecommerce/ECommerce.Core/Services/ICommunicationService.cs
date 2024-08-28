using ECommerce.Core.Entities;
using static ECommerce.Core.Services.IService;

namespace ECommerce.Core.Services
{
    public interface ICommunicationService : IService<Communications>
    {
        Task<IEnumerable<Communications>> GetCommunicationsByCustomerIdAsync(int customerId);
    }
}
