using System.Threading.Tasks;
using FoodApp.Models;

namespace FoodApp.Services
{
    public interface IUserService
    {
        Task<bool> CheckPasswordAsync(long userId, string password);
        Task<User> CreateAsync(User user, string password);
        Task<User> FindByNameAsync(string username);
        Task<string> GetRoleAsync(long userId);
    }
}