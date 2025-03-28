using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster; // Для маппинга объектов
using ExcursionAPI.Contracts.Tours; // Для использования DTO (CreateTourRequest)

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/tours
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы с турами (Tours)
        private readonly ITourService _toursService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public ToursController(ITourService toursService)
        {
            _toursService = toursService;
        }

        /// <summary>
        /// Получает все туры.
        /// </summary>
        /// <returns>Список всех туров в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всех туров
            var tours = await _toursService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(tours);
        }

        /// <summary>
        /// Получает тур по его ID.
        /// </summary>
        /// <param name="id">Идентификатор тура.</param>
        /// <returns>Тур в формате JSON или HTTP 404 Not Found, если тур не найден.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения тура по ID
            var tour = await _toursService.GetById(id);

            // Если тур не найден, возвращаем HTTP 404 Not Found
            if (tour == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(tour);
        }

        /// <summary>
        /// Добавляет новый тур (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateTourRequest, содержащий данные для создания тура.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTourRequest request)
        {
            // Проверяем, что входные данные не являются null
            if (request == null)
                return BadRequest("Invalid request data.");

            // Преобразуем объект запроса (DTO) в модель домена (Tour) с помощью Mapster
            var tourDto = request.Adapt<Tour>();

            // Вызываем метод сервиса для создания нового тура
            await _toursService.Create(tourDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующий тур.
        /// </summary>
        /// <param name="tour">Объект Tour, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Tour tour)
        {
            // Вызываем метод сервиса для обновления тура
            await _toursService.Update(tour);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет тур по его ID.
        /// </summary>
        /// <param name="id">Идентификатор тура.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления тура
            await _toursService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}