using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster; // Для маппинга объектов
using ExcursionAPI.Contracts.Subscriptions; // Для использования DTO (CreateSubscriptionRequest)

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/subscriptions
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы с подписками (Subscriptions)
        private readonly ISubscriptionService _subscriptionService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        /// <summary>
        /// Получает все подписки.
        /// </summary>
        /// <returns>Список всех подписок в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всех подписок
            var subscriptions = await _subscriptionService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(subscriptions);
        }

        /// <summary>
        /// Получает подписку по её ID.
        /// </summary>
        /// <param name="id">Идентификатор подписки.</param>
        /// <returns>Подписка в формате JSON или HTTP 404 Not Found, если подписка не найдена.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения подписки по ID
            var subscription = await _subscriptionService.GetById(id);

            // Если подписка не найдена, возвращаем HTTP 404 Not Found
            if (subscription == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(subscription);
        }

        /// <summary>
        /// Добавляет новую подписку (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateSubscriptionRequest, содержащий данные для создания подписки.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateSubscriptionRequest request)
        {
            // Проверяем, что входные данные не являются null
            if (request == null)
                return BadRequest("Invalid request data.");

            // Преобразуем объект запроса (DTO) в модель домена (Subscription) с помощью Mapster
            var subscriptionDto = request.Adapt<Subscription>();

            // Вызываем метод сервиса для создания новой подписки
            await _subscriptionService.Create(subscriptionDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующую подписку.
        /// </summary>
        /// <param name="subscription">Объект Subscription, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Subscription subscription)
        {
            // Вызываем метод сервиса для обновления подписки
            await _subscriptionService.Update(subscription);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет подписку по её ID.
        /// </summary>
        /// <param name="id">Идентификатор подписки.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления подписки
            await _subscriptionService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}
