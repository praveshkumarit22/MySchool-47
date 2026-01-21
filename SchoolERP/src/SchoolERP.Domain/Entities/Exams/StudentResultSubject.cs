namespace SchoolERP.Domain.Entities.Exams;

public class StudentResultSubject
{
    public string Id { get; set; } = default!;
    public string StudentResultId { get; set; } = default!;
    public string SubjectId { get; set; } = default!;

    public decimal MaxMarks { get; set; }
    public decimal ObtainedMarks { get; set; }
    public bool IsAbsent { get; set; }
    public string? Grade { get; set; }

    public StudentResult StudentResult { get; set; } = default!;
}
