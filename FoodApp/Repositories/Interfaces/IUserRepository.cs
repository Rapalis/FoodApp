using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Models;

namespace FoodApp.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        public Task<User> FindByNameAsync(string username);
    }
}