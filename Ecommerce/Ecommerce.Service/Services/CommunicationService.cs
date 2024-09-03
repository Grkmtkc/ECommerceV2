using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Service.Services        
{
    public class CommunicationService : Service<Communications>, ICommunicationService
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IGenericRepository<Communications> _communicationRepository;

        public CommunicationService(IUnitOfWorks unitOfWork, IGenericRepository<Communications> communicationRepository)
            : base(communicationRepository, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _communicationRepository = communicationRepository;
        }

        public async Task<IEnumerable<Communications>> GetCommunicationsByCustomerIdAsync(int customerId)
        {
            return await _communicationRepository
                .Where(c => c.CustomerId == customerId && c.IsActive && !c.IsDeleted)
                 .Include(c => c.Customer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Communications>> GetActiveCommunicationsAsync()
        {
            return await _communicationRepository
                .Where(c => c.IsActive && !c.IsDeleted)
                .ToListAsync();
        }
    }
}
