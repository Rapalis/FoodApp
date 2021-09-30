using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Repositories
{
    public interface IReviewsRepository: IBaseRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllAsync(long dishId);
    }
}
