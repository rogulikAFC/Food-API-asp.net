using System.ComponentModel.DataAnnotations;

namespace FoodAPI.Models
{
    public class CategoryForCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
