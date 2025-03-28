using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster; // Для маппинга объектов
using ExcursionAPI.Contracts.Statistic;
using Domain.Interfacess; 

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/statistic
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы со статистикой (Statistics)
        private readonly IStatisticService _statisticService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        /// <summary>
        /// Получает всю статистику.
        /// </summary>
        /// <returns>Список всей статистики в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всей статистики
            var statistics = await _statisticService.GetAll();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(statistics);
        }

        /// <summary>
        /// Получает статистику по её ID.
        /// </summary>
        /// <param name="id">Идентификатор статистики.</param>
        /// <returns>Статистика в формате JSON или HTTP 404 Not Found, если статистика не найдена.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения статистики по ID
            var statistic = await _statisticService.GetById(id);

            // Если статистика не найдена, возвращаем HTTP 404 Not Found
            if (statistic == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(statistic);
        }

        /// <summary>
        /// Добавляет новую статистику (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateStatisticRequest, содержащий данные для создания статистики.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateStatisticRequest request)
        {
            // Проверяем, что входные данные не являются null
            if (request == null)
                return BadRequest("Invalid request data.");

            // Преобразуем объект запроса (DTO) в модель домена (Statistic) с помощью Mapster
            var statisticDto = request.Adapt<Statistic>();

            // Вызываем метод сервиса для создания новой статистики
            await _statisticService.Create(statisticDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующую статистику.
        /// </summary>
        /// <param name="statistic">Объект Statistic, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Statistic statistic)
        {
            // Вызываем метод сервиса для обновления статистики
            await _statisticService.Update(statistic);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет статистику по её ID.
        /// </summary>
        /// <param name="id">Идентификатор статистики.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления статистики
            await _statisticService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}