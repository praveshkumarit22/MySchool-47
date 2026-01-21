namespace SchoolERP.Application.Exams.Requests;

public sealed class GenerateResultRequest
{
    public string ExamId { get; set; } = default!;
    public string StudentId { get; set; } = default!;
}
