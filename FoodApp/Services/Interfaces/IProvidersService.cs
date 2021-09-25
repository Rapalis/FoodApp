using FoodApp.Models;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public interface IProvidersService
    {
        Task<ProviderDTO> GetAsync(long id);
        Task<ProviderDTO> GetAllAsync();
        Task<ProviderDTO> CreateAsync(CreateProviderDTO createRequestDTO);
        Task<ProviderDTO> UpdateAsync(long id, CreateProviderDTO updateRequestDTO);
        Task<bool> DeleteAsync(long id);
    }
}