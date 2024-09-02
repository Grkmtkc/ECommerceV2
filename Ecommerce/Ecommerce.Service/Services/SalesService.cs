using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Service.Services
{
    public class SalesService : Service<Sales>, ISaleService
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IGenericRepository<Sales> _salesRepository;

        public SalesService(IUnitOfWorks unitOfWork, IGenericRepository<Sales> salesRepository)
            : base(salesRepository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _salesRepository = salesRepository;
        }

        public async Task<Sales> GetSalesWithDetailsByIdAsync(int saleId)
        {
            return await _salesRepository
                .Where(s => s.Id == saleId && s.IsActive && !s.IsDeleted)
                .Include(s => s.Customer)
                .Include(s => s.Product)
                .FirstOrDefaultAsync();
        }
    }
}
