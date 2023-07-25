namespace FoodAPI.Models
{
    public class DishDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public CategoryDto Category { get; set; } = null!;
        public IEnumerable<StepDto> Recipe { get; set; } = null!;

    }
}
