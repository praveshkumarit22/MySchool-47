namespace SchoolERP.Application.Exams.Requests;

public sealed class SaveMarksRequest
{
    public string ExamSubjectId { get; set; } = default!;
    public List<StudentMarkItem> Students { get; set; } = [];
}

public sealed class StudentMarkItem
{
    public string StudentId { get; set; } = default!;
    public decimal ObtainedMarks { get; set; }
    public string? Grade { get; set; }
    public string? Remarks { get; set; }
}
