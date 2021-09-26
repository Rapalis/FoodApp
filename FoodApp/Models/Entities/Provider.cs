using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Models
{
    public class Provider: BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }
        public IEnumerable<Dish> Servings { get; set; } = new List<Dish>();
    }
}
