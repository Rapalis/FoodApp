using FoodApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Repositories
{
    public interface IDishesRepository : IBaseRepository<Dish>
    {
        Task<IEnumerable<Dish>> GetAllAsync(long providerId); 
    }
}
