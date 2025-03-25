namespace Domain.Models;

public class Complaint
{
    public int ComplaintId { get; set; }

    public int? UserId { get; set; }

    public int? TourId { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Tour? Tour { get; set; }

    public virtual User? User { get; set; }
}
