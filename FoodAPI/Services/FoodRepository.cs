using FoodAPI.DbContexts;
using FoodAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Services
{
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodContext _context;

        public FoodRepository(FoodContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void AddDish(Dish dish)
        {
            _context.Dishes.Add(dish);
        }

        public async Task<bool> AddStepAsync(Guid dishId, Step step)
        {
            var dish = await _context
                .Dishes
                .FindAsync(dishId);

            if (dish == null)
            {
                return false;
            }

            dish.Recipe.Add(step);

            return true;
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public void DeleteDish(Dish dish)
        {
            _context.Dishes.Remove(dish);
        }

        public void DeleteStep(Step step)
        {
            _context.Steps.Remove(step);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int pageNumber, int pageSize)
        {
            return await _context.Categories
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _context.Categories
                .FindAsync(categoryId);
        }

        public async Task<Dish?> GetDishByIdAsync(Guid dishId)
        {
            return await _context.Dishes
                .FindAsync(dishId);
        }

        public async Task<IEnumerable<Dish>> GetDishesAsync(int pageNumber, int pageSize)
        {
            return await _context.Dishes
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
