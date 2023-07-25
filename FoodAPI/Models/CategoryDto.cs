namespace FoodAPI.Models
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<DishDto> Dishes { get; set; } = null!;
    }
}
