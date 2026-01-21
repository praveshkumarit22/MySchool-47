namespace SchoolERP.Domain.Entities.Students;

public class StudentDocument
{
    public string Id { get; set; } = default!;
    public string StudentId { get; set; } = default!;

    public string DocumentType { get; set; } = default!; // BirthCert, Aadhaar, TC
    public string FileUrl { get; set; } = default!;

    public Student Student { get; set; } = default!;
}
