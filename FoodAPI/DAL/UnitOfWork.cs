﻿using FoodAPI.DbContexts;
using FoodAPI.Entities;

namespace FoodAPI.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoodContext _foodContext;
        public IGenericRepository<Dish> DishesRepository { get; set; }
        public IStepRepository StepsRepository { get; set; }
        public IGenericRepository<Category> CategoriesRepository { get; set; }

        public UnitOfWork(FoodContext foodContext)
        {
            _foodContext = foodContext
                ?? throw new ArgumentNullException(nameof(foodContext));

            DishesRepository = new GenericRepository<Dish>(foodContext);
            StepsRepository = new StepRepository(foodContext);
            CategoriesRepository = new GenericRepository<Category>(foodContext);
        }

        public async Task SaveChangesAsync()
        {
            await _foodContext.SaveChangesAsync();
        }
    }
}
