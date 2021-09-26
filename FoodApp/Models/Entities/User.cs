using FoodApp.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace FoodApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        public UserRoles Role { get; set; }
        //public IEnumerable<IBillingProfile> Billing { get; set; }
        //public IEnumerable<Address> Addresses { get; set; }
    }
}
