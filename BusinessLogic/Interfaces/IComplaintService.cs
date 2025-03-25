using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IComplaintService
    {
        Task<List<Complaint>> GetAll();
        Task<Complaint> GetById(int id);
        Task Create(Complaint model);
        Task Update(Complaint model);
        Task Delete(int id);
    }
}