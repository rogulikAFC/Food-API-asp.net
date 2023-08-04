﻿namespace FoodAPI.Models
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<DishForPreview> Dishes { get; set; } = null!;
    }
}
