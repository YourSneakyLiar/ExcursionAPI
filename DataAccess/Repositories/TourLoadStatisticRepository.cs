using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class TourLoadStatisticRepository : RepositoryBase<TourLoadStatistic>, ITourLoadStatisticRepository
    {
        public TourLoadStatisticRepository(ExcursionBdContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}