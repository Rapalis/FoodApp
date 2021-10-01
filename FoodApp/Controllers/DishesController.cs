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
    public class DishesController : ControllerBase
    {
        private readonly IDishesService _dishesService;

        public DishesController(IDishesService dishesService)
        {
            _dishesService = dishesService;
        }

        [HttpGet(RouteConsts.PROVIDERS_DISHES_ENDPOINT_URL)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DishDTO>>> GetAll(long providerId)
        {
            IEnumerable<DishDTO> receivedDishes = await _dishesService.GetAllAsync(providerId);
            if (receivedDishes == null)
                return NotFound();
            return Ok(receivedDishes);
        }

        [HttpGet(RouteConsts.DISHES_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DishDTO>> Get(long id)
        {
            DishDTO receivedDish = await _dishesService.GetAsync(id);
            if (receivedDish == null)
                return NotFound();
            return Ok(receivedDish);
        }

        [HttpPost (RouteConsts.PROVIDERS_DISHES_ENDPOINT_URL)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DishDTO>> Post(long providerId, [FromBody] CreateDishDTO createRequestDTO)
        {
            DishDTO createdDish = await _dishesService.CreateAsync(providerId, createRequestDTO);
            if (createdDish == null)
                return NotFound();
            return CreatedAtAction(nameof(Get), new { id = createdDish.Id }, createdDish);
        }

        [HttpPut(RouteConsts.DISHES_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DishDTO>> Put(long id, [FromBody] CreateDishDTO updateRequestDTO)
        {
            DishDTO updatedDish = await _dishesService.UpdateAsync(id, updateRequestDTO);
            if (updatedDish == null)
                return NotFound();
            return Ok(updatedDish);
        }

        [HttpDelete(RouteConsts.DISHES_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(long id)
        {
            if (!await _dishesService.DeleteAsync(id))
                return NotFound();
            return NoContent();
        }
    }
}
