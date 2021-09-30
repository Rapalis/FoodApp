using FoodApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public interface IDishesService
    {
        Task<DishDTO> GetAsync(long id);
        Task<IEnumerable<DishDTO>> GetAllAsync(long providerId);
        Task<DishDTO> CreateAsync(long providerId, CreateDishDTO createRequestDTO);
        Task<DishDTO> UpdateAsync(long id, CreateDishDTO updateRequestDTO);
        Task<bool> DeleteAsync(long id);
    }
}
