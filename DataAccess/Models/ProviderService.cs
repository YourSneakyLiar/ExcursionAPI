using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ProviderService
{
    public int ServiceId { get; set; }

    public int? ProviderId { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User? Provider { get; set; }
}
