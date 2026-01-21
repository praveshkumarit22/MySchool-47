namespace SchoolERP.Application.Exams.Requests;

public sealed class AddExamSubjectRequest
{
    public string ExamId { get; set; } = default!;
    public string SubjectId { get; set; } = default!;
    public decimal MaxMarks { get; set; }
    public DateOnly ExamDate { get; set; }
}
