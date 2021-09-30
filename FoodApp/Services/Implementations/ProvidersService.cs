using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodApp.Models;
using FoodApp.Repositories;

namespace FoodApp.Services
{
    public class ProvidersService: IProvidersService
    {
        private readonly IProvidersRepository _providersRepository;
        private readonly IMapper _mapper;

        public ProvidersService(IProvidersRepository providersRepository, IMapper mapper)
        {
            _providersRepository = providersRepository;
            _mapper = mapper;
        }

        public async Task<ProviderDTO> GetAsync(long id)
        {
            Provider outResultEntity = await _providersRepository.GetAsync(id);
            return _mapper.Map<ProviderDTO>(outResultEntity);
        }

        public async Task<IEnumerable<ProviderDTO>> GetAllAsync()
        {
            IEnumerable<Provider> outResultEntities = await _providersRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderDTO>>(outResultEntities);
        }

        public async Task<ProviderDTO> CreateAsync(CreateProviderDTO createRequestDTO)
        {
            Provider providerEntity = _mapper.Map<Provider>(createRequestDTO);
            providerEntity = await _providersRepository.CreateAsync(providerEntity);
            return _mapper.Map<ProviderDTO>(providerEntity);
        }

        public async Task<ProviderDTO> UpdateAsync(long id, CreateProviderDTO updateRequestDTO)
        {
            Provider providerEntity = _mapper.Map<Provider>(updateRequestDTO);
            providerEntity.Id = id;
            providerEntity = await _providersRepository.UpdateAsync(providerEntity);
            return _mapper.Map<ProviderDTO>(providerEntity);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _providersRepository.DeleteAsync(id);
        }
    }
}
