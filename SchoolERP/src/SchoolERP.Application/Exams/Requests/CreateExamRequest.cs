namespace SchoolERP.Application.Exams.Requests;

public sealed class CreateExamRequest
{
    public string AcademicYearId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Term { get; set; } = default!;
}
