﻿using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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