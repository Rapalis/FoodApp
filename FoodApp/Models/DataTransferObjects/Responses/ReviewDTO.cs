using System;

namespace FoodApp.Models.DataTransferObjects
{
    public class ReviewDTO
    {
        public long Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }
        public short Score { get; set; }
    }
}
