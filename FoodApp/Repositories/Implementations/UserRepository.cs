using FoodApp.DataAccess;
using FoodApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DatabaseContext _dbCtx;

        public UserRepository(DatabaseContext dbCtx) : base(dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public async Task<User> FindByNameAsync (string username)
        {
            return await _dbCtx.User.Where(u=> u.UserName == username).SingleOrDefaultAsync();
        }
    }
}
