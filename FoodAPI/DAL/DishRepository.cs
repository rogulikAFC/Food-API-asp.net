using FoodAPI.DbContexts;
using FoodAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.DAL
{
    public class DishRepository : GenericRepository<Dish>
    {
        public DishRepository(
            FoodContext foodContext) : base(foodContext)
        { }

        public async override Task<IEnumerable<Dish>> GetAllAsync(
            int pageNum, int pageSize)
        {
            return await _foodContext
                .Dishes
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .Include(
                    d => d.Recipe
                    .OrderBy(s => s.SerialNumber))
                .Include(d => d.Category)
                .ToListAsync();
        }

        public async override Task<Dish?> GetByIdAsync(Guid id)
        {
            return await _foodContext
                .Dishes
                .Where(d => d.Id == id)
                .Include(
                    d => d.Recipe
                    .OrderBy(s => s.SerialNumber))
                .Include(d => d.Category)
                .FirstOrDefaultAsync();
        }
    }
}
