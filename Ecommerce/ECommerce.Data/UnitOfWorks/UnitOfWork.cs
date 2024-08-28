using ECommerce.Core.UnitOfWorks;
using ECommerce.Data.Context;


namespace ECommerce.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly ECommerceDbContext _context;

        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
