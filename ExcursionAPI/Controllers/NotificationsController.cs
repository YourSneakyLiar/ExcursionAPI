using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster; // Для маппинга объектов
using ExcursionAPI.Contracts.Notifications; // Для использования DTO (CreateNotificationRequest)

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/notifications
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы с уведомлениями (Notifications)
        private readonly INotificationService _notificationService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Получает все уведомления.
        /// </summary>
        /// <returns>Список всех уведомлений в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всех уведомлений
            var notifications = await _notificationService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(notifications);
        }

        /// <summary>
        /// Получает уведомление по его ID.
        /// </summary>
        /// <param name="id">Идентификатор уведомления.</param>
        /// <returns>Уведомление в формате JSON или HTTP 404 Not Found, если уведомление не найдено.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения уведомления по ID
            var notification = await _notificationService.GetById(id);

            // Если уведомление не найдено, возвращаем HTTP 404 Not Found
            if (notification == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(notification);
        }

        /// <summary>
        /// Добавляет новое уведомление (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateNotificationRequest, содержащий данные для создания уведомления.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateNotificationRequest request)
        {
            // Преобразуем объект запроса (DTO) в модель домена (Notification) с помощью Mapster
            var notificationDto = request.Adapt<Notification>();

            // Вызываем метод сервиса для создания нового уведомления
            await _notificationService.Create(notificationDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующее уведомление.
        /// </summary>
        /// <param name="notification">Объект Notification, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Notification notification)
        {
            // Вызываем метод сервиса для обновления уведомления
            await _notificationService.Update(notification);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет уведомление по его ID.
        /// </summary>
        /// <param name="id">Идентификатор уведомления.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления уведомления
            await _notificationService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}