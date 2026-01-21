namespace SchoolERP.Domain.Entities.Students;

public class StudentGuardian
{
    public string Id { get; set; } = default!;
    public string StudentId { get; set; } = default!;

    public string FullName { get; set; } = default!;
    public string Relation { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string? Email { get; set; }
    public string? Occupation { get; set; }

    public Student Student { get; set; } = default!;
}
