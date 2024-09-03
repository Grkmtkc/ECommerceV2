using ECommerce.Core.Entities;
using static ECommerce.Core.Services.IService;

namespace ECommerce.Core.Services
{
    public interface IAddressService : IService<Addresses>
    {
        
        Task<IEnumerable<Addresses>> GetAddressesByCustomerIdAsync(int customerId);
    }
}
