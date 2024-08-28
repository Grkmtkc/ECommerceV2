using ECommerce.Core.Entities;
using static ECommerce.Core.Services.IService;

namespace ECommerce.Core.Services
{
    public interface ISalesService : IService<Sales>
    {
        Task<Sales> GetSalesWithDetailsByIdAsync(int saleId);
    }
}
