using FoodApp.Models.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public interface IReviewsService
    {
        Task<ReviewDTO> GetAsync(long id);
        Task<IEnumerable<ReviewDTO>> GetAllAsync(long dishId);
        Task<ReviewDTO> CreateAsync(long dishId, CreateReviewDTO createRequestDTO);
        Task<ReviewDTO> UpdateAsync(long id, CreateReviewDTO updateRequestDTO);
        Task<bool> DeleteAsync(long id);
    }
}
