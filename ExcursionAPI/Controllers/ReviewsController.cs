using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ExcursionAPI.Contracts.Reviews; // Для использования DTO (CreateReviewRequest)
using Mapster; // Для маппинга объектов

namespace ExcursionAPI.Controllers
{
    // Определяем маршрут для контроллера: api/reviews
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        // Внедрение зависимости сервиса для работы с отзывами (Reviews)
        private readonly IReviewService _reviewsService;

        // Конструктор для внедрения сервиса через DI (Dependency Injection)
        public ReviewsController(IReviewService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        /// <summary>
        /// Получает все отзывы.
        /// </summary>
        /// <returns>Список всех отзывов в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Вызываем метод сервиса для получения всех отзывов
            var reviews = await _reviewsService.GetAll();
            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(reviews);
        }

        /// <summary>
        /// Получает отзыв по его ID.
        /// </summary>
        /// <param name="id">Идентификатор отзыва.</param>
        /// <returns>Отзыв в формате JSON или HTTP 404 Not Found, если отзыв не найден.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Вызываем метод сервиса для получения отзыва по ID
            var review = await _reviewsService.GetById(id);

            // Если отзыв не найден, возвращаем HTTP 404 Not Found
            if (review == null)
                return NotFound();

            // Возвращаем результат в формате HTTP 200 OK с данными
            return Ok(review);
        }

        /// <summary>
        /// Добавляет новый отзыв (используя модель DTO).
        /// </summary>
        /// <param name="request">Объект CreateReviewRequest, содержащий данные для создания отзыва.</param>
        /// <returns>HTTP 200 OK в случае успешного добавления.</returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateReviewRequest request)
        {
            // Проверяем, что входные данные не являются null
            if (request == null)
                return BadRequest("Invalid request data.");

            // Преобразуем объект запроса (DTO) в модель домена (Review) с помощью Mapster
            var reviewDto = request.Adapt<Review>();

            // Вызываем метод сервиса для создания нового отзыва
            await _reviewsService.Create(reviewDto);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Обновляет существующий отзыв.
        /// </summary>
        /// <param name="review">Объект Review, содержащий обновленные данные.</param>
        /// <returns>HTTP 200 OK в случае успешного обновления.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(Review review)
        {
            // Вызываем метод сервиса для обновления отзыва
            await _reviewsService.Update(review);

            // Возвращаем HTTP 200 OK
            return Ok();
        }

        /// <summary>
        /// Удаляет отзыв по его ID.
        /// </summary>
        /// <param name="id">Идентификатор отзыва.</param>
        /// <returns>HTTP 200 OK в случае успешного удаления.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Вызываем метод сервиса для удаления отзыва
            await _reviewsService.Delete(id);

            // Возвращаем HTTP 200 OK
            return Ok();
        }
    }
}