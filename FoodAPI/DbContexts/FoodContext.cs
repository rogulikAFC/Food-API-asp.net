using FoodAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.DbContexts
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) 
        {

        }

        public DbSet<Dish> Dishes { get; set; } = null!;
        public DbSet<Step> Steps { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}
