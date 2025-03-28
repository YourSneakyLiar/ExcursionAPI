using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ExcursionAPI.Contracts.Roles; // Для использования DTO (CreateRoleRequest)
using Mapster; // Для маппинга объектов

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/roles
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы с ролями (Roles)
        private readonly IRoleService _roleService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Получает все роли.
        /// </summary>
        /// <returns>Список всех ролей в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всех ролей
            var roles = await _roleService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(roles);
        }

        /// <summary>
        /// Получает роль по её ID.
        /// </summary>
        /// <param name="id">Идентификатор роли.</param>
        /// <returns>Роль в формате JSON или HTTP 404 Not Found, если роль не найдена.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения роли по ID
            var role = await _roleService.GetById(id);

            // Если роль не найдена, возвращаем HTTP 404 Not Found
            if (role == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(role);
        }

        /// <summary>
        /// Добавляет новую роль (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateRoleRequest, содержащий данные для создания роли.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateRoleRequest request)
        {
            // Проверяем, что входные данные не являются null
            if (request == null)
                return BadRequest("Invalid request data.");

            // Преобразуем объект запроса (DTO) в модель домена (Role) с помощью Mapster
            var roleDto = request.Adapt<Role>();

            // Вызываем метод сервиса для создания новой роли
            await _roleService.Create(roleDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующую роль.
        /// </summary>
        /// <param name="role">Объект Role, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Role role)
        {
            // Вызываем метод сервиса для обновления роли
            await _roleService.Update(role);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет роль по её ID.
        /// </summary>
        /// <param name="id">Идентификатор роли.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления роли
            await _roleService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}