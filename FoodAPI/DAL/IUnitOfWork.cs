using FoodAPI.Entities;

namespace FoodAPI.DAL
{
    public interface IUnitOfWork
    {
        IGenericRepository<Dish> DishesRepository { get; set; }
        IStepRepository StepsRepository { get; set; }
        IGenericRepository<Category> CategoriesRepository { get; set; }
        Task SaveChangesAsync();
    }
}
