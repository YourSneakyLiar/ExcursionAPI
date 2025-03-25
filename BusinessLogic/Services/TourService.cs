using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TourService : ITourService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TourService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Task<List<Tour>> GetAll()
        {
            return _repositoryWrapper.Tour.FindAll().ToListAsync();
        }

        public Task<Tour> GetById(int id)
        {
            var tour = _repositoryWrapper.Tour
                .FindByCondition(x => x.TourId == id).First();
            return Task.FromResult(tour);
        }

        public Task Create(Tour model)
        {
            _repositoryWrapper.Tour.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Update(Tour model)
        {
            _repositoryWrapper.Tour.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var tour = _repositoryWrapper.Tour
                .FindByCondition(x => x.TourId == id).First();

            _repositoryWrapper.Tour.Delete(tour);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}