using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Models;

namespace FoodApp.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<Review>> GetAllAsync(long dishId);
    }
}