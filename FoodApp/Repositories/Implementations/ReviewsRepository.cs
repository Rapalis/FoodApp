using FoodApp.DataAccess;
using FoodApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Repositories.Implementations
{
    public class ReviewsRepository: BaseRepository<Review>, IReviewsRepository
    {
        private readonly DatabaseContext _dbCtx;

        public ReviewsRepository(DatabaseContext dbCtx) : base(dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public async Task<IEnumerable<Review>> GetAllAsync(long dishId)
        {
            return await _dbCtx.Review.Where(d => d.DishID == dishId).ToListAsync();
        }
    }
}
