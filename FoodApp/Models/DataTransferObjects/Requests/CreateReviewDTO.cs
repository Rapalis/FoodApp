using System;

namespace FoodApp.Models.DataTransferObjects
{
    public class CreateReviewDTO
    {
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }
        public short Score { get; set; }
    }
}
