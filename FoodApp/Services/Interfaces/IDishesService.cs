using FoodApp.Models;
using FoodApp.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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
