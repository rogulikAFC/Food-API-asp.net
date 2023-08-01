using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Models
{
    public class StepForCreateDto
    {
        [Required]
        public string Text { get; set; } = null!;

        [Required]
        public Guid DishId { get; set; }
    }
}
