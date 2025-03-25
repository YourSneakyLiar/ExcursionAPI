using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IStatisticService
    {
        Task<List<Statistic>> GetAll();
        Task<Statistic> GetById(int id);
        Task Create(Statistic model);
        Task Update(Statistic model);
        Task Delete(int id);
    }
}