using FoodAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FoodAPI.DbContexts
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) 
        { }

        public DbSet<Dish> Dishes { get; set; } = null!;
        public DbSet<Step> Steps { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Category)
                .WithMany(c => c.Dishes)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
 