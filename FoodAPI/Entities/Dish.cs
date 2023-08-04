using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Entities
{
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public Guid? CategoryId { get; set; }

        public Category? Category { get; set; }

        // [Required]
        // public virtual ICollection<Step> Recipe { get; set; } = new List<Step>();

        public virtual ICollection<Step> Recipe { get; set; } = new List<Step>();
    }
}
