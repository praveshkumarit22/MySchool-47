namespace SchoolERP.Application.Students.Requests;

public sealed class EnrollStudentRequest
{
    public string StudentId { get; set; } = default!;
    public string AcademicYearId { get; set; } = default!;
    public string ClassId { get; set; } = default!;
    public string SectionId { get; set; } = default!;
}
