using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ExcursionAPI.Contracts.Complaints;
using Mapster;

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/complaints
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы с жалобами (Complaints)
        private IComplaintService _complaintService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public ComplaintsController(IComplaintService complaintsService)
        {
            _complaintService = complaintsService;
        }

        /// <summary>
        /// Получает все жалобы.
        /// </summary>
        /// <returns>Список всех жалоб в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всех жалоб
            var complaints = await _complaintService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(complaints);
        }

        /// <summary>
        /// Получает жалобу по её ID.
        /// </summary>
        /// <param name="id">Идентификатор жалобы.</param>
        /// <returns>Жалоба в формате JSON или HTTP 404 Not Found, если жалоба не найдена.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения жалобы по ID
            var complaint = await _complaintService.GetById(id);
            // Если жалоба не найдена, возвращаем HTTP 404 Not Found
            if (complaint == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(complaint);
        }

        /// <summary>
        /// Добавляет новую жалобу (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateComplaintRequest, содержащий данные о жалобе.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateComplaintRequest request)
        {
            // Преобразуем объект запроса (DTO) в модель домена (Complaint) с помощью Mapster
            var complaintDto = request.Adapt<Complaint>();

            // Вызываем метод сервиса для создания новой жалобы
            await _complaintService.Create(complaintDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующую жалобу.
        /// </summary>
        /// <param name="complaints">Объект Complaint, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Complaint complaints)
        {
            // Вызываем метод сервиса для обновления жалобы
            await _complaintService.Update(complaints);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет жалобу по её ID.
        /// </summary>
        /// <param name="id">Идентификатор жалобы.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления жалобы
            await _complaintService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}