using BusinessLogic.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private IStatisticService _statisticService;
        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _statisticService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _statisticService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Statistic statistic)
        {
            await _statisticService.Create(statistic);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Statistic statistic)
        {
            await _statisticService.Update(statistic);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _statisticService.Delete(id);
            return Ok();
        }
    }
}