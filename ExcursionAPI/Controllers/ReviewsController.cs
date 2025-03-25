using BusinessLogic.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IReviewService _reviewsService;
        public ReviewsController(IReviewService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _reviewsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _reviewsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Review reviews)
        {
            await _reviewsService.Create(reviews);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Review reviews)
        {
            await _reviewsService.Update(reviews);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _reviewsService.Delete(id);
            return Ok();
        }
    }
}
