using BusinessLogic.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private ITourService _toursService;
        public ToursController(ITourService toursService)
        {
            _toursService = toursService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _toursService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _toursService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Tour tours)
        {
            await _toursService.Create(tours);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Tour tours)
        {
            await _toursService.Update(tours);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _toursService.Delete(id);
            return Ok();
        }
    }
}
