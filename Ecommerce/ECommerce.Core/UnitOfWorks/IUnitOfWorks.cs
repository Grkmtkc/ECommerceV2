﻿

namespace ECommerce.Core.UnitOfWorks
{
    public interface IUnitOfWorks
    {
        Task CommitAsync();
        void Commit();
        Task CompleteAsync();
    }
}
