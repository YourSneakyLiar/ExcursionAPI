using Domain.Interfaces;
using Domain.Interfacess;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class StatisticService : IStatisticService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public StatisticService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Statistic>> GetAll()
        {
            return _repositoryWrapper.Statistic.FindAll().ToListAsync();
        }

        public Task<Statistic> GetById(int id)
        {
            var statistic = _repositoryWrapper.Statistic
                .FindByCondition(x => x.StatisticId == id).First();
            return Task.FromResult(statistic);
        }

        public Task Create(Statistic model)
        {
            _repositoryWrapper.Statistic.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Statistic model)
        {
            _repositoryWrapper.Statistic.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var statistic = _repositoryWrapper.Statistic
                .FindByCondition(x => x.StatisticId == id).First();

            _repositoryWrapper.Statistic.Delete(statistic);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}