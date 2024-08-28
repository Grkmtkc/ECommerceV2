using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;



namespace Ecommerce.Service.Services
{
    public class AddressService : Service<Addresses>, IAddressService
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IGenericRepository<Addresses> _addressRepository;

        public AddressService(IUnitOfWorks unitOfWork, IGenericRepository<Addresses> addressRepository)
            : base(addressRepository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<Addresses>> GetAddressesByCustomerIdAsync(int customerId)
        {
            return await _addressRepository
                .Where(a => a.CustomerId == customerId)
                .Include(x => x.Customer)
                .ToListAsync();
        }
    }
}
