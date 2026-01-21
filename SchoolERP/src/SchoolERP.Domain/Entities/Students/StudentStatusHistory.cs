namespace SchoolERP.Domain.Entities.Students;

public class StudentStatusHistory
{
    public string Id { get; set; } = default!;
    public string StudentId { get; set; } = default!;

    public string OldStatus { get; set; } = default!;
    public string NewStatus { get; set; } = default!;
    public string Reason { get; set; } = default!;
    public DateTime ChangedOn { get; set; } = DateTime.UtcNow;
}
