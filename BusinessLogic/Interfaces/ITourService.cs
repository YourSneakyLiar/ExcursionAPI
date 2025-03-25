using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITourService
    {
        Task<List<Tour>> GetAll();
        Task<Tour> GetById(int id);
        Task Create(Tour model);
        Task Update(Tour model);
        Task Delete(int id);
    }
}