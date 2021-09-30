using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
