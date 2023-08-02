using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Models
{
    public class CategoryForUpdateDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
