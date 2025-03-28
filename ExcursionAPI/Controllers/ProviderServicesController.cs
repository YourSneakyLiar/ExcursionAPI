using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster; // Для маппинга объектов
using ExcursionAPI.Contracts.ProviderServices; // Для использования DTO (CreateProviderServiceRequest)

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/providerservices
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderServicesController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы с услугами провайдеров (Provider Services)
        private readonly IProviderServiceService _providerServiceService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public ProviderServicesController(IProviderServiceService providerServicesService)
        {
            _providerServiceService = providerServicesService;
        }

        /// <summary>
        /// Получает все услуги провайдеров.
        /// </summary>
        /// <returns>Список всех услуг провайдеров в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всех услуг провайдеров
            var providerServices = await _providerServiceService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(providerServices);
        }

        /// <summary>
        /// Получает услугу провайдера по её ID.
        /// </summary>
        /// <param name="id">Идентификатор услуги провайдера.</param>
        /// <returns>Услуга провайдера в формате JSON или HTTP 404 Not Found, если услуга не найдена.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения услуги провайдера по ID
            var providerService = await _providerServiceService.GetById(id);

            // Если услуга не найдена, возвращаем HTTP 404 Not Found
            if (providerService == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(providerService);
        }

        /// <summary>
        /// Добавляет новую услугу провайдера (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateProviderServiceRequest, содержащий данные для создания услуги провайдера.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateProviderServiceRequest request)
        {
            // Проверяем, что входные данные не являются null
            if (request == null)
                return BadRequest("Invalid request data.");

            // Преобразуем объект запроса (DTO) в модель домена (ProviderService) с помощью Mapster
            var providerServiceDto = request.Adapt<ProviderService>();

            // Вызываем метод сервиса для создания новой услуги провайдера
            await _providerServiceService.Create(providerServiceDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующую услугу провайдера.
        /// </summary>
        /// <param name="providerService">Объект ProviderService, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(ProviderService providerService)
        {
            // Вызываем метод сервиса для обновления услуги провайдера
            await _providerServiceService.Update(providerService);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет услугу провайдера по её ID.
        /// </summary>
        /// <param name="id">Идентификатор услуги провайдера.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления услуги провайдера
            await _providerServiceService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}