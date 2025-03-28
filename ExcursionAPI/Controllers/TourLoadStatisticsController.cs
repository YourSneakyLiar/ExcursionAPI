using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster; // Для маппинга объектов
using ExcursionAPI.Contracts.TourLoadStatistics; // Для использования DTO (CreateTourLoadStatisticRequest)

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/tourloadstatistics
    [Route("api/[controller]")]
    [ApiController]
    public class TourLoadStatisticsController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы со статистикой загрузки туров (Tour Load Statistics)
        private readonly ITourLoadStatisticService _tourLoadStatisticService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public TourLoadStatisticsController(ITourLoadStatisticService tourLoadStatisticService)
        {
            _tourLoadStatisticService = tourLoadStatisticService;
        }

        /// <summary>
        /// Получает всю статистику загрузки туров.
        /// </summary>
        /// <returns>Список всей статистики загрузки туров в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всей статистики загрузки туров
            var tourLoadStatistics = await _tourLoadStatisticService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(tourLoadStatistics);
        }

        /// <summary>
        /// Получает статистику загрузки тура по её ID.
        /// </summary>
        /// <param name="id">Идентификатор статистики загрузки тура.</param>
        /// <returns>Статистика загрузки тура в формате JSON или HTTP 404 Not Found, если статистика не найдена.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения статистики загрузки тура по ID
            var tourLoadStatistic = await _tourLoadStatisticService.GetById(id);

            // Если статистика загрузки тура не найдена, возвращаем HTTP 404 Not Found
            if (tourLoadStatistic == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(tourLoadStatistic);
        }

        /// <summary>
        /// Добавляет новую статистику загрузки тура (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateTourLoadStatisticRequest, содержащий данные для создания статистики загрузки тура.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateTourLoadStatisticRequest request)
        {
            // Проверяем, что входные данные не являются null
            if (request == null)
                return BadRequest("Invalid request data.");

            // Преобразуем объект запроса (DTO) в модель домена (TourLoadStatistic) с помощью Mapster
            var tourLoadStatisticDto = request.Adapt<TourLoadStatistic>();

            // Вызываем метод сервиса для создания новой статистики загрузки тура
            await _tourLoadStatisticService.Create(tourLoadStatisticDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующую статистику загрузки тура.
        /// </summary>
        /// <param name="tourLoadStatistic">Объект TourLoadStatistic, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(TourLoadStatistic tourLoadStatistic)
        {
            // Вызываем метод сервиса для обновления статистики загрузки тура
            await _tourLoadStatisticService.Update(tourLoadStatistic);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет статистику загрузки тура по её ID.
        /// </summary>
        /// <param name="id">Идентификатор статистики загрузки тура.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления статистики загрузки тура
            await _tourLoadStatisticService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}