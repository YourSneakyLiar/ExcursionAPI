using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class TourRepository : RepositoryBase<Tour>, ITourRepository
    {
        public TourRepository(ExcursionBdContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}