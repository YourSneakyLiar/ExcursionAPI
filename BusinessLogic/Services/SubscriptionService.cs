using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SubscriptionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Subscription>> GetAll()
        {
            return _repositoryWrapper.Subscription.FindAll().ToListAsync();
        }

        public Task<Subscription> GetById(int id)
        {
            var subscription = _repositoryWrapper.Subscription
                .FindByCondition(x => x.SubscriptionId == id).First();
            return Task.FromResult(subscription);
        }

        public Task Create(Subscription model)
        {
            _repositoryWrapper.Subscription.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Subscription model)
        {
            _repositoryWrapper.Subscription.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var subscription = _repositoryWrapper.Subscription
                .FindByCondition(x => x.SubscriptionId == id).First();

            _repositoryWrapper.Subscription.Delete(subscription);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}