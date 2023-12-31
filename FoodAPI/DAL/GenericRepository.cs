﻿using FoodAPI.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FoodContext _foodContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(FoodContext foodContext)
        {
            _foodContext = foodContext
                ?? throw new ArgumentNullException(nameof(foodContext));

            _dbSet = _foodContext.Set<T>();
        }

        public async virtual Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> IsExistAsync(Guid id)
        {
            return await _dbSet.FindAsync(id) != null;
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync(
            int pageNum = 1, int pageSize = 5)
        {
            return await _dbSet
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                return;
            }

            _dbSet.Remove(entity);
        }
    }
}
