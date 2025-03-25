using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProviderServiceService : IProviderServiceService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProviderServiceService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<ProviderService>> GetAll()
        {
            return _repositoryWrapper.ProviderService.FindAll().ToListAsync();
        }

        public Task<ProviderService> GetById(int id)
        {
            var providerService = _repositoryWrapper.ProviderService
                .FindByCondition(x => x.ServiceId == id).First();
            return Task.FromResult(providerService);
        }

        public Task Create(ProviderService model)
        {
            _repositoryWrapper.ProviderService.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(ProviderService model)
        {
            _repositoryWrapper.ProviderService.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var providerService = _repositoryWrapper.ProviderService
                .FindByCondition(x => x.ServiceId == id).First();

            _repositoryWrapper.ProviderService.Delete(providerService);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}