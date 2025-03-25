using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class StatisticRepository : RepositoryBase<Statistic>, IStatisticRepository
    {
        public StatisticRepository(ExcursionBdContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}