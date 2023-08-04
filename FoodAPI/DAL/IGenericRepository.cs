using System.Linq.Expressions;

namespace FoodAPI.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            int pageNum, int pageSize);
        Task<bool> IsExistAsync(Guid id);
        Task<T?> GetByIdAsync(Guid id);
        void Add(T entity);
        Task DeleteAsync(Guid id);
    }
}
