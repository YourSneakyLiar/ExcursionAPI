using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Subscription
{
    public int SubscriptionId { get; set; }

    public int? UserId { get; set; }

    public string Type { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
