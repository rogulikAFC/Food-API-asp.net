using FoodAPI.DbContexts;
using FoodAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.DAL
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(FoodContext foodContext) : base(foodContext)
        { }

        public async override Task<Category?> GetByIdAsync(Guid id)
        {
            return await _foodContext
                .Categories
                .Where(c => c.Id == id)
                .Include(c => c.Dishes)
                .FirstOrDefaultAsync();
        }

        public async override Task<IEnumerable<Category>> GetAllAsync(
            int pageNum = 1, int pageSize = 5)
        {
            return await _foodContext
                .Categories
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .Include(c => c.Dishes)
                .ToListAsync();
        }
    }
}
