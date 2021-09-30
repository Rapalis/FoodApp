using FoodApp.DataAccess;
using FoodApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Repositories
{
    public class DishesRepository : BaseRepository<Dish>, IDishesRepository
    {
        private readonly DatabaseContext _dbCtx;

        public DishesRepository(DatabaseContext dbCtx) : base(dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public async Task<IEnumerable<Dish>> GetAllAsync(long providerId)
        {
             return await _dbCtx.Dish.Where(d => d.ProviderId == providerId).ToListAsync();
        }
    }
}
