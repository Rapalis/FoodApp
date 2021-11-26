using FoodApp.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Models
{
    public class User: BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
        //public IEnumerable<IBillingProfile> Billing { get; set; }
        //public IEnumerable<Address> Addresses { get; set; }
    }
}
