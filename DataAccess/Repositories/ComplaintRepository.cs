using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class ComplaintRepository : RepositoryBase<Complaint>, IComplaintRepository
    {
        public ComplaintRepository(ExcursionBdContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}