using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ExcursionAPI.Contracts.Orders; // Для использования DTO (CreateOrderRequest)
using Mapster; // Для маппинга объектов

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/orders
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы с заказами (Orders)
        private readonly IOrderService _orderService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Получает все заказы.
        /// </summary>
        /// <returns>Список всех заказов в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всех заказов
            var orders = await _orderService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(orders);
        }

        /// <summary>
        /// Получает заказ по его ID.
        /// </summary>
        /// <param name="id">Идентификатор заказа.</param>
        /// <returns>Заказ в формате JSON или HTTP 404 Not Found, если заказ не найден.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения заказа по ID
            var order = await _orderService.GetById(id);

            // Если заказ не найден, возвращаем HTTP 404 Not Found
            if (order == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(order);
        }

        /// <summary>
        /// Добавляет новый заказ (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateOrderRequest, содержащий данные для создания заказа.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderRequest request)
        {
            // Преобразуем объект запроса (DTO) в модель домена (Order) с помощью Mapster
            var orderDto = request.Adapt<Order>();

            // Вызываем метод сервиса для создания нового заказа
            await _orderService.Create(orderDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующий заказ.
        /// </summary>
        /// <param name="order">Объект Order, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Order order)
        {
            // Вызываем метод сервиса для обновления заказа
            await _orderService.Update(order);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет заказ по его ID.
        /// </summary>
        /// <param name="id">Идентификатор заказа.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления заказа
            await _orderService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}