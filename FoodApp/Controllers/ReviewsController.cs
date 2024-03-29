﻿using FoodApp.Constants;
using FoodApp.Models.DataTransferObjects;
using FoodApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodApp.Controllers
{
    [Route(RouteConsts.BASE_URL)]
    [Authorize]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _reviewsService;
        private readonly IDishesService _dishesService;
        private readonly IProvidersService _providersService;


        public ReviewsController(IReviewsService reviewsService, IDishesService dishesService, IProvidersService providersService)
        {
            _providersService = providersService;
            _dishesService = dishesService;
            _reviewsService = reviewsService;
        }

        [HttpGet(RouteConsts.DISHES_REVIEWS_ENDPOINT_URL)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAll(long providerId, long dishId)
        {
            var receivedProvider = await _providersService.GetAsync(providerId);
            if (receivedProvider == null)
                return NotFound();
            var receivedDish = await _dishesService.GetAsync(dishId);
            if (receivedDish == null)
                return NotFound();
            IEnumerable<ReviewDTO> receivedReviews = await _reviewsService.GetAllAsync(dishId);
            if (receivedReviews == null)
                return NotFound();
            return Ok(receivedReviews);
        }

        [HttpGet(RouteConsts.DISHES_REVIEWS_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDTO>> Get(long providerId, long dishId, long id)
        {
            var receivedProvider = await _providersService.GetAsync(providerId);
            if (receivedProvider == null)
                return NotFound();
            var receivedDish = await _dishesService.GetAsync(dishId);
            if (receivedDish == null)
                return NotFound();
            ReviewDTO receivedReview = await _reviewsService.GetAsync(id);
            if (receivedReview == null)
                return NotFound();
            return Ok(receivedReview);
        }

        [HttpPost(RouteConsts.DISHES_REVIEWS_ENDPOINT_URL)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ReviewDTO>> Post(long providerId, long dishId, [FromBody] CreateReviewDTO createRequestDTO)
        {
            var receivedProvider = await _providersService.GetAsync(providerId);
            if (receivedProvider == null)
                return NotFound();
            var receivedDish = await _dishesService.GetAsync(dishId);
            if (receivedDish == null)
                return NotFound();
            ReviewDTO createdReview = await _reviewsService.CreateAsync(dishId, createRequestDTO, Convert.ToInt64(User.FindFirstValue("userId")));
            if (createdReview == null)
                return NotFound();
            return CreatedAtAction(nameof(Get), new { providerId = providerId, dishId = dishId, id = createdReview.Id }, createdReview);
        }

        [HttpPut(RouteConsts.DISHES_REVIEWS_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReviewDTO>> Put(long providerId, long dishId, long id, [FromBody] CreateReviewDTO updateRequestDTO)
        {
            var receivedProvider = await _providersService.GetAsync(providerId);
            if (receivedProvider == null)
                return NotFound();
            var receivedDish = await _dishesService.GetAsync(dishId);
            if (receivedDish == null)
                return NotFound();

            var review = await _reviewsService.GetAsync(id);
            if (review == null)
                return NotFound();
            if (Convert.ToInt64(User.FindFirstValue("userId")) != review.UserId && User.FindFirstValue(ClaimTypes.Role) != "Admin")
                return Forbid();

            ReviewDTO updatedProvider = await _reviewsService.UpdateAsync(id, updateRequestDTO);
            return Ok(updatedProvider);
        }

        [HttpDelete(RouteConsts.DISHES_REVIEWS_ENDPOINT_URL + "/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(long providerId, long dishId, long id)
        {
            var receivedProvider = await _providersService.GetAsync(providerId);
            if (receivedProvider == null)
                return NotFound();
            var receivedDish = await _dishesService.GetAsync(dishId);
            if (receivedDish == null)
                return NotFound();

            var review = await  _reviewsService.GetAsync(id);
            if(review == null)
                return NotFound();
            if (Convert.ToInt64(User.FindFirstValue("userId")) != review.UserId && User.FindFirstValue(ClaimTypes.Role) != "Admin")
                return Forbid();

            await _reviewsService.DeleteAsync(id);

            return NoContent();
        }
    }
}
