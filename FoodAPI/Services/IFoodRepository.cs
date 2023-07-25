using FoodAPI.Entities;

namespace FoodAPI.Services
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(int pageNumber, int pageSize);
        Task<Category?> GetCategoryByIdAsync(Guid categoryId);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        Task<IEnumerable<Dish>> GetDishesAsync(int pageNumber, int pageSize);
        Task<Dish?> GetDishByIdAsync(Guid dishId);
        void AddDish(Dish dish);
        void DeleteDish(Dish dish);
        Task<bool> AddStepAsync(Guid dishId, Step step);
        void DeleteStep(Step step);
        Task<bool> SaveChangesAsync();
    }
}
