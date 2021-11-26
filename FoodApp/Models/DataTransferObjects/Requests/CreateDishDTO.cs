
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Models
{
    public class CreateDishDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
