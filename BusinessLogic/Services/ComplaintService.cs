using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ComplaintService : IComplaintService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ComplaintService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Complaint>> GetAll()
        {
            return _repositoryWrapper.Complaint.FindAll().ToListAsync();
        }

        public Task<Complaint> GetById(int id)
        {
            var complaint = _repositoryWrapper.Complaint
                .FindByCondition(x => x.ComplaintId == id).First();
            return Task.FromResult(complaint);
        }

        public Task Create(Complaint model)
        {
            _repositoryWrapper.Complaint.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Complaint model)
        {
            _repositoryWrapper.Complaint.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var complaint = _repositoryWrapper.Complaint
                .FindByCondition(x => x.ComplaintId == id).First();

            _repositoryWrapper.Complaint.Delete(complaint);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}