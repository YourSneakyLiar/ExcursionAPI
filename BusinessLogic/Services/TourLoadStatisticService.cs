using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TourLoadStatisticService : ITourLoadStatisticService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TourLoadStatisticService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<TourLoadStatistic>> GetAll()
        {
            return _repositoryWrapper.TourLoadStatistic.FindAll().ToListAsync();
        }

        public Task<TourLoadStatistic> GetById(int id)
        {
            var tourLoadStatistic = _repositoryWrapper.TourLoadStatistic
                .FindByCondition(x => x.StatisticId == id).First();
            return Task.FromResult(tourLoadStatistic);
        }

        public Task Create(TourLoadStatistic model)
        {
            _repositoryWrapper.TourLoadStatistic.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(TourLoadStatistic model)
        {
            _repositoryWrapper.TourLoadStatistic.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var tourLoadStatistic = _repositoryWrapper.TourLoadStatistic
                .FindByCondition(x => x.StatisticId == id).First();

            _repositoryWrapper.TourLoadStatistic.Delete(tourLoadStatistic);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}