using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ProviderServiceRepository : RepositoryBase<ProviderService>, IProviderServiceRepository
    {
        public ProviderServiceRepository(ExcursionBdContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}