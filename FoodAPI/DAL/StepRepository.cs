using FoodAPI.DbContexts;
using FoodAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.DAL
{
    public class StepRepository : GenericRepository<Step>, IStepRepository
    {
        public StepRepository(FoodContext foodContext) : base(foodContext) { }

        public async Task<bool> AddStepAsync(Step entity)
        {
            var dish = await _foodContext
                .Dishes
                .Where(d => d.Id == entity.DishId)
                .Include(d => d.Recipe)
                .FirstAsync();

            if (dish == null)
            {
                return false;
            }

            var maxSerialNumber = dish
                .Recipe
                .Max(s => s.SerialNumber);

            entity.SerialNumber = maxSerialNumber++;
            
            base.Add(entity);

            return true;
        }
    }
}
