using FoodApp.Constants;
using FoodApp.Models;
using FoodApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route(RouteConsts.BASE_URL)]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProvidersService _providersService;

        public ProvidersController(IProvidersService providersService)
        {
            _providersService = providersService;
        }

        [HttpGet(RouteConsts.PROVIDERS_ENDPOINT_URL)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProviderDTO>>> GetAll()
        {
            return Ok(await _providersService.GetAllAsync());
        }

        [HttpGet(RouteConsts.PROVIDERS_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProviderDTO>> Get(long id)
        {
            ProviderDTO receivedProvider = await _providersService.GetAsync(id);
            if (receivedProvider == null)
                return NotFound();
            return Ok(receivedProvider);
        }

        [HttpPost(RouteConsts.PROVIDERS_ENDPOINT_URL)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProviderDTO>> Post([FromBody] CreateProviderDTO createRequestDTO)
        {
            ProviderDTO createdProvider = await _providersService.CreateAsync(createRequestDTO);
            return CreatedAtAction(nameof(Get), new { id = createdProvider.Id }, createdProvider);
        }

        [HttpPut(RouteConsts.PROVIDERS_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProviderDTO>> Put(long id, [FromBody] CreateProviderDTO updateRequestDTO)
        {
            ProviderDTO updatedProvider = await _providersService.UpdateAsync(id, updateRequestDTO);
            if (updatedProvider == null)
                return NotFound();
            return Ok(updatedProvider);
        }

        [HttpDelete(RouteConsts.PROVIDERS_ENDPOINT_URL + "/{id}")]
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
