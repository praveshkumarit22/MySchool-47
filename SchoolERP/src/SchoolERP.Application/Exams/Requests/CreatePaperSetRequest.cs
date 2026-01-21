namespace SchoolERP.Application.Exams.Requests;

public sealed class CreatePaperSetRequest
{
    public string ExamPaperId { get; set; } = default!;
    public string SetName { get; set; } = default!;
}
