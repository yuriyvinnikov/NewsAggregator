using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoriesContracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> AddAsync(T entity);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(T entity);
        public Task<bool> CheckIfEntityExistsAsync(int id);
    }
}
