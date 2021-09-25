using System.Net;
using System.Threading.Tasks;
using FoodApp.Models;

namespace FoodApp.Services
{
    public class ProvidersService: IProvidersService
    {
        public async Task<ProviderDTO> GetAsync(long id)
        {
            if (id == 10)
            {
                return null;
            }
            return new ProviderDTO { Name = "Simple name", Address = "Definitely not fake address" };
        }

        public Task<ProviderDTO> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProviderDTO> CreateAsync(CreateProviderDTO createRequestDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProviderDTO> UpdateAsync(long id, CreateProviderDTO updateRequestDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
