﻿using ECommerce.Core.Entities;

namespace ECommerce.Core.Repositories
{
    public interface IAddressRepository : IGenericRepository<Addresses>
    {
        Task<IEnumerable<Addresses>> GetAddressesByCustomerIdAsync(int customerId);
        Task<IEnumerable<Addresses>> GetActiveAddressesAsync();
    }
}



