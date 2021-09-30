using FoodApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Repositories
{
    public interface IReviewsRepository: IBaseRepository<Review>
    {
        Task<IEnumerable<Review>> GetAllAsync(long dishId);
    }
}
