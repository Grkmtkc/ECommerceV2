using System.Linq.Expressions;


namespace ECommerce.Core.Services
{
    public interface IService
    {
        public interface IService<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetById(int id);
            IQueryable<T> Where(Expression<Func<T, bool>> expression);
            Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
            Task<T> AddAsync(T entity);
            Task UpdateAsync(T entity);
            Task RemoveAsync(T entity);
        }
    }
}
