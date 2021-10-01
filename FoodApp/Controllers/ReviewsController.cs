using FoodApp.Constants;
using FoodApp.Models.DataTransferObjects;
using FoodApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route(RouteConsts.BASE_URL)]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [HttpGet(RouteConsts.DISHES_REVIEWS_ENDPOINT_URL)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAll(long dishId)
        {
            IEnumerable<ReviewDTO> receivedReviews = await _reviewsService.GetAllAsync(dishId);
            if (receivedReviews == null)
                return NotFound();
            return Ok(receivedReviews);
        }

        [HttpGet(RouteConsts.REVIEWS_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDTO>> Get(long id)
        {
            ReviewDTO receivedProvider = await _reviewsService.GetAsync(id);
            if (receivedProvider == null)
                return NotFound();
            return Ok(receivedProvider);
        }

        [HttpPost (RouteConsts.DISHES_REVIEWS_ENDPOINT_URL)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReviewDTO>> Post(long dishId, [FromBody] CreateReviewDTO createRequestDTO)
        {
            ReviewDTO createdReview = await _reviewsService.CreateAsync(dishId, createRequestDTO);
            if (createdReview == null)
                return NotFound();
            return CreatedAtAction(nameof(Get), new { id = createdReview.Id }, createdReview);
        }

        [HttpPut(RouteConsts.REVIEWS_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDTO>> Put(long id, [FromBody] CreateReviewDTO updateRequestDTO)
        {
            ReviewDTO updatedProvider = await _reviewsService.UpdateAsync(id, updateRequestDTO);
            if (updatedProvider == null)
                return NotFound();
            return Ok(updatedProvider);
        }

        [HttpDelete(RouteConsts.REVIEWS_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(long id)
        {
            if (!await _reviewsService.DeleteAsync(id))
                return NotFound();
            return NoContent();
        }
    }
}
