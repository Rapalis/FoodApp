using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Models
{
    public class Dish
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(4000)]
        public string Description { get; set; }
        [Required]
        public long ProviderId { get; set; }
        public Provider Provider { get;set; }
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
    }
}
