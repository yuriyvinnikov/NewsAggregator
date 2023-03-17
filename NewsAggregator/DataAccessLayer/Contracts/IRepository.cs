using DataAccessLayer.Entities;
using System.Linq.Expressions;

namespace DataAccessLayer.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        public Task<T> AddAsync(T entity);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(T entity);
        public Task<bool> CheckIfEntityExistsAsync(int id);
    }
}
