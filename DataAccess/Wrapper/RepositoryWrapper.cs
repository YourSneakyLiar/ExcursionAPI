﻿using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ExcursionBdContext _repoContext;
        private IUserRepository _user;
        private IComplaintRepository _complaint;
        private INotificationRepository _notification;
        private IOrderRepository _order;
        private IProviderServiceRepository _providerService;
        private IReviewRepository _review;
        private IRoleRepository _role;
        private IStatisticRepository _statistic;
        private ISubscriptionRepository _subscription;
        private ITourLoadStatisticRepository _tourLoadStatistic;
        private ITourRepository _tour;

        public RepositoryWrapper(ExcursionBdContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public IComplaintRepository Complaint
        {
            get
            {
                if (_complaint == null)
                {
                    _complaint = new ComplaintRepository(_repoContext);
                }

                return _complaint;
            }
        }

        public INotificationRepository Notification
        {
            get
            {
                if (_notification == null)
                {
                    _notification = new NotificationRepository(_repoContext);
                }

                return _notification;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_repoContext);
                }

                return _order;
            }
        }

        public IProviderServiceRepository ProviderService
        {
            get
            {
                if (_providerService == null)
                {
                    _providerService = new ProviderServiceRepository(_repoContext);
                }

                return _providerService;
            }
        }

        public IReviewRepository Review
        {
            get
            {
                if (_review == null)
                {
                    _review = new ReviewRepository(_repoContext);
                }

                return _review;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_repoContext);
                }

                return _role;
            }
        }

        public IStatisticRepository Statistic
        {
            get
            {
                if (_statistic == null)
                {
                    _statistic = new StatisticRepository(_repoContext);
                }

                return _statistic;
            }
        }

        public ISubscriptionRepository Subscription
        {
            get
            {
                if (_subscription == null)
                {
                    _subscription = new SubscriptionRepository(_repoContext);
                }

                return _subscription;
            }
        }

        public ITourLoadStatisticRepository TourLoadStatistic
        {
            get
            {
                if (_tourLoadStatistic == null)
                {
                    _tourLoadStatistic = new TourLoadStatisticRepository(_repoContext);
                }

                return _tourLoadStatistic;
            }
        }

        public ITourRepository Tour
        {
            get
            {
                if (_tour == null)
                {
                    _tour = new TourRepository(_repoContext);
                }

                return _tour;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}