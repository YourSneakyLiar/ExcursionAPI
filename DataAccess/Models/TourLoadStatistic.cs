using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class TourLoadStatistic
{
    public int StatisticId { get; set; }

    public int? TourId { get; set; }

    public int AvailableSeats { get; set; }

    public int BookedSeats { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual Tour? Tour { get; set; }
}
