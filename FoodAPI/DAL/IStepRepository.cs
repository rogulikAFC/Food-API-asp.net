using FoodAPI.Entities;

namespace FoodAPI.DAL
{
    public interface IStepRepository : IGenericRepository<Step>
    {
        Task<bool> AddStepAsync(Step step);
    }
}
