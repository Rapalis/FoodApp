using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Models
{
    public class Review: BaseEntity
    {
        [Required]
        public DateTimeOffset Date { get; set; }
        [Required]
        [MaxLength(4000)]
        public string Message { get; set; }
        [Required]
        public short Score { get; set; }
        [Required]
        public long UserId { get; set; }
        public User User { get; set; }
        [Required]
        public long DishID { get; set; }
        public Dish Dish { get; set; }
    }
}
