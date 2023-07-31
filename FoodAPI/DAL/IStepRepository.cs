using FoodAPI.Entities;

namespace FoodAPI.DAL
{
    public interface IStepRepository : IGenericRepository<Step>
    {
        void AddStep(Guid dishId, Step step);
    }
}
