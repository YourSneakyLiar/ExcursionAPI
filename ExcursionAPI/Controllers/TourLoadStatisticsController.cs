using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourLoadStatisticsController : ControllerBase
    {
        private ITourLoadStatisticService _tourLoadStatisticService;
        public TourLoadStatisticsController(ITourLoadStatisticService tourLoadStatisticsService)
        {
            _tourLoadStatisticService = tourLoadStatisticsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tourLoadStatisticService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _tourLoadStatisticService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(TourLoadStatistic tourLoadStatistics)
        {
            await _tourLoadStatisticService.Create(tourLoadStatistics);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(TourLoadStatistic tourLoadStatistics)
        {
            await _tourLoadStatisticService.Update(tourLoadStatistics);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _tourLoadStatisticService.Delete(id);
            return Ok();
        }
    }
}

