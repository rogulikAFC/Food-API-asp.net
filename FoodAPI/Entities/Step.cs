using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Entities
{
    public class Step
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; } = null!;

        // public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();

        public int SerialNumber { get; set; } = 0;

        [Required]
        public Guid DishId { get; set; }

        public virtual Dish Dish { get; set; } = null!;
    }
}
