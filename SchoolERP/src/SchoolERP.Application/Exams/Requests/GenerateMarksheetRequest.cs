namespace SchoolERP.Application.Exams.Requests;

public sealed class GenerateMarksheetRequest
{
    public string ExamId { get; set; } = default!;
    public string StudentId { get; set; } = default!;
}
