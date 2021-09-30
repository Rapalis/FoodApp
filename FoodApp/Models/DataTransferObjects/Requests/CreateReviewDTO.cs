using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Models.DataTransferObjects
{
    public class CreateReviewDTO
    {
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }
        public short Score { get; set; }
    }
}
