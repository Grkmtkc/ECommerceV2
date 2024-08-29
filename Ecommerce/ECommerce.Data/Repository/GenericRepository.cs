using ECommerce.Core.Repositories;
using ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace ECommerce.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ECommerceDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity); //ef core add methodu
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AnyAsync(expression); //ef core any methodu
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id); // ef core find method
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
