using FoodAPI.DbContexts;
using FoodAPI.Entities;

namespace FoodAPI.DAL
{
    public class StepRepository : GenericRepository<Step>, IStepRepository
    {
        public StepRepository(FoodContext foodContext) : base(foodContext) { }

        public async void AddStep(Guid dishId, Step step)
        {
            var dish = await _foodContext.Dishes
                .FindAsync(dishId);

            if (dish == null)
            {
                return;
            }

            dish.Recipe.Add(step);
        }
    }
}
