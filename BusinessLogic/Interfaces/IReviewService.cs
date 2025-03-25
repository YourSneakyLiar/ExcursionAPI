using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IReviewService
    {
        Task<List<Review>> GetAll();
        Task<Review> GetById(int id);
        Task Create(Review model);
        Task Update(Review model);
        Task Delete(int id);
    }
}