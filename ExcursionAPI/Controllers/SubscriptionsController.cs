using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private ISubscriptionService _subscriptionsService;
        public SubscriptionsController(ISubscriptionService subscriptionsService)
        {
            _subscriptionsService = subscriptionsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _subscriptionsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _subscriptionsService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Subscription subscriptions)
        {
            await _subscriptionsService.Create(subscriptions);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Subscription subscriptions)
        {
            await _subscriptionsService.Update(subscriptions);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _subscriptionsService.Delete(id);
            return Ok();
        }
    }
}
