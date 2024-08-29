using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Services
{
    public class CustomerService : Service<Customers>, ICustomerService
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IGenericRepository<Customers> _customerRepository;

        public CustomerService(IUnitOfWorks unitOfWork, IGenericRepository<Customers> customerRepository)
            : base(customerRepository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        

        public async Task<Customers> GetCustomerWithDetailsByIdAsync(int customerId)
        {
            return await _customerRepository
                .Where(c => c.Id == customerId && c.IsActive && !c.IsDeleted)
                .Include(c => c.Addresses)
                .Include(c => c.Communications)
                .Include(c => c.Sales)
                .FirstOrDefaultAsync();
        }
    }
}