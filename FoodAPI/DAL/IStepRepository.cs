using FoodAPI.Entities;

namespace FoodAPI.DAL
{
    public interface IStepRepository : IGenericRepository<Step>
    {
        Task AddStepAsync(Guid dishId, Step step);
    }
}
