using FoodApp.Constants;
using FoodApp.Models;
using FoodApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route(RouteConsts.PROVIDERS_ENDPOINT_URL)]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProvidersService _providersService;

        public ProvidersController(IProvidersService providersService)
        {
            _providersService = providersService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProviderDTO>>> Get()
        {
            return Ok(await _providersService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProviderDTO>> Get(long id)
        {
            ProviderDTO receivedProvider = await _providersService.GetAsync(id);
            if (receivedProvider == null)
                return NotFound();
            return Ok(receivedProvider);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProviderDTO>> Post([FromBody] CreateProviderDTO createRequestDTO)
        {
            return Ok(await _providersService.CreateAsync(createRequestDTO));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProviderDTO>> Put(long id, [FromBody] CreateProviderDTO updateRequestDTO)
        {
            ProviderDTO updatedProvider = await _providersService.UpdateAsync(id, updateRequestDTO);
            if (updatedProvider == null)
                return NotFound();
            return Ok(updatedProvider);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(long id)
        {
            if (!await _providersService.DeleteAsync(id))
                return NotFound();
            return NoContent();
        }
    }
}
