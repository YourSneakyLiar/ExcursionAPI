using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
namespace DataAccess.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(ExcursionBdContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}