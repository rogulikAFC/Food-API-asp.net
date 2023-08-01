using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Models
{
    public class StepForUpdateDto
    {
        [Required]
        public string Text { get; set; } = null!;
    }
}
