using AutoMapper;
using FoodApp.Models;
using FoodApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Services
{
    public class DishesService : IDishesService
    {
        private readonly IDishesRepository _dishesRepository;
        private readonly IProvidersRepository _providersRepository;
        private readonly IMapper _mapper;

        public DishesService(IProvidersRepository providersRepository, IDishesRepository dishesRepository, IMapper mapper)
        {
            _providersRepository = providersRepository;
            _dishesRepository = dishesRepository;
            _mapper = mapper;
        }

        public async Task<DishDTO> GetAsync(long id)
        {
            Dish outResultEntity = await _dishesRepository.GetAsync(id);
            return _mapper.Map<DishDTO>(outResultEntity);
        }

        public async Task<IEnumerable<DishDTO>> GetAllAsync(long providerId)
        {
            if (!await _providersRepository.Exists(providerId))
                return null;
            IEnumerable<Dish> outResultEntities = await _dishesRepository.GetAllAsync(providerId);
            return _mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(outResultEntities);
        }

        public async Task<DishDTO> CreateAsync(long providerId, CreateDishDTO createRequestDTO)
        {
            if (!await _providersRepository.Exists(providerId))
                return null;
            Dish dishEntity = _mapper.Map<Dish>(createRequestDTO);
            dishEntity.ProviderId = providerId;
            dishEntity = await _dishesRepository.CreateAsync(dishEntity);
            return _mapper.Map<DishDTO>(dishEntity);
        }

        public async Task<DishDTO> UpdateAsync(long id, CreateDishDTO updateRequestDTO)
        {
            Dish dishEntity = _mapper.Map<Dish>(updateRequestDTO);
            dishEntity.Id = id;
            dishEntity = await _dishesRepository.UpdateAsync(dishEntity);
            return _mapper.Map<DishDTO>(dishEntity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _dishesRepository.DeleteAsync(id);
        }
    }
}
