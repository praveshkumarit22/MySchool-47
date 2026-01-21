namespace SchoolERP.Domain.Entities.Students;

public class StudentPromotionHistory
{
    public string Id { get; set; } = default!;
    public string StudentId { get; set; } = default!;

    public string FromEnrollmentId { get; set; } = default!;
    public string ToEnrollmentId { get; set; } = default!;

    public DateTime PromotedOn { get; set; } = DateTime.UtcNow;
    public string Remarks { get; set; } = default!;
}
