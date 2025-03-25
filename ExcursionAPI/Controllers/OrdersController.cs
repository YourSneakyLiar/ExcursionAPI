using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;
        public OrdersController(IOrderService ordersService)
        {
            _orderService = ordersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _orderService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order orders)
        {
            await _orderService.Create(orders);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Order orders)
        {
            await _orderService.Update(orders);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.Delete(id);
            return Ok();
        }
    }
}