using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IProviderServiceService
    {
        Task<List<ProviderService>> GetAll();
        Task<ProviderService> GetById(int id);
        Task Create(ProviderService model);
        Task Update(ProviderService model);
        Task Delete(int id);
    }
}