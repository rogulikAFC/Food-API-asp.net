using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Models
{
    public class DishForUpdateDto
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
