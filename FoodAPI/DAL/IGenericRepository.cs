namespace FoodAPI.DAL
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int pageNum, int pageSize);
        Task<bool> IsExist(Guid id);
        Task<T?> GetByIdAsync(Guid id);
        void Add(T entity);
        Task DeleteAsync(Guid id);
    }
}
