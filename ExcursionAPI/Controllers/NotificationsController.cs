using BusinessLogic.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {

        private INotificationService _notificationService;
        public NotificationsController(INotificationService notificationsService)
        {
            _notificationService = notificationsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _notificationService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _notificationService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Notification notifications)
        {
            await _notificationService.Create(notifications);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Notification notifications)
        {
            await _notificationService.Update(notifications);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _notificationService.Delete(id);
            return Ok();
        }
    }
}