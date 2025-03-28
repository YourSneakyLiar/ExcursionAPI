using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster; // Для маппинга объектов
using ExcursionAPI.Contracts.Users; // Для использования DTO (CreateUserRequest)

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/user
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы с пользователями (Users)
        private readonly IUserService _userService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Получает всех пользователей.
        /// </summary>
        /// <returns>Список всех пользователей в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всех пользователей
            var users = await _userService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(users);
        }

        /// <summary>
        /// Получает пользователя по его ID.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>Пользователь в формате JSON или HTTP 404 Not Found, если пользователь не найден.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения пользователя по ID
            var user = await _userService.GetById(id);

            // Если пользователь не найден, возвращаем HTTP 404 Not Found
            if (user == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(user);
        }

        /// <summary>
        /// Добавляет нового пользователя (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateUserRequest, содержащий данные для создания пользователя.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            // Проверяем, что входные данные не являются null
            if (request == null)
                return BadRequest("Invalid request data.");

            // Преобразуем объект запроса (DTO) в модель домена (User) с помощью Mapster
            var userDto = request.Adapt<User>();

            // Вызываем метод сервиса для создания нового пользователя
            await _userService.Create(userDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующего пользователя.
        /// </summary>
        /// <param name="user">Объект User, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            // Вызываем метод сервиса для обновления пользователя
            await _userService.Update(user);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет пользователя по его ID.
        /// </summary>
        /// <param name="id">Идентификатор пользователя.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления пользователя
            await _userService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}