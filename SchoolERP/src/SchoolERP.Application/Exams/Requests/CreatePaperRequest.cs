namespace SchoolERP.Application.Exams.Requests;

public sealed class CreatePaperRequest
{
    public string ExamId { get; set; } = default!;
    public string SubjectId { get; set; } = default!;
    public decimal MaxMarks { get; set; }
    public int DurationMinutes { get; set; }
}
