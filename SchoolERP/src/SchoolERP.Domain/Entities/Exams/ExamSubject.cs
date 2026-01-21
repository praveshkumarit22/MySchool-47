namespace SchoolERP.Domain.Entities.Exams;

public class ExamSubject
{
    public string Id { get; set; } = default!;
    public string ExamId { get; set; } = default!;
    public string SubjectId { get; set; } = default!;

    public decimal MaxMarks { get; set; }
    public DateOnly ExamDate { get; set; }

    public Exam Exam { get; set; } = default!;
    public ICollection<StudentMark> Marks { get; set; } = new List<StudentMark>();
}
