using SchoolERP.Domain.Entities.Exams;

public class StudentMark
{
    public string Id { get; set; } = default!;
    public string ExamSubjectId { get; set; } = default!;
    public string StudentId { get; set; } = default!;

    public decimal ObtainedMarks { get; set; }
    public bool IsAbsent { get; set; }
    public bool IsExempt { get; set; }

    public string? Grade { get; set; }
    public string? Remarks { get; set; }

    public ExamSubject ExamSubject { get; set; } = default!;
}
