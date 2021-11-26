using System.Threading.Tasks;
using FoodApp.Models;

namespace FoodApp.Utils
{
    public interface IAuthService
    {
        Task<string> CreateAccessTokenAsync(User user);
    }
}