using System;

namespace FoodApp.Models.DataTransferObjects
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
