using FoodApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Repositories
{
    public interface IDishesRepository : IBaseRepository<Dish>
    {
        Task<IEnumerable<Dish>> GetAllAsync(long providerId); 
    }
}
