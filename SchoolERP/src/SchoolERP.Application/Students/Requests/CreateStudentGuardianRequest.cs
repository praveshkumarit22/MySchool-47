namespace SchoolERP.Application.Students.Requests;

public sealed class CreateStudentGuardianRequest
{
    public string FullName { get; set; } = default!;
    public string Relation { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string? Email { get; set; }
    public string? Occupation { get; set; }
}
