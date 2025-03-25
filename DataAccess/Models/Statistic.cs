using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Statistic
{
    public int StatisticId { get; set; }

    public int? TourId { get; set; }

    public int? TotalBookings { get; set; }

    public decimal? TotalRevenue { get; set; }

    public virtual Tour? Tour { get; set; }
}
