namespace SchoolERP.Domain.Entities.Exams;

public class ExamPaper
{
    public string Id { get; set; } = default!;
    public string ExamId { get; set; } = default!;
    public string SubjectId { get; set; } = default!;

    public decimal MaxMarks { get; set; }
    public int DurationMinutes { get; set; }

    public ICollection<ExamPaperSet> Sets { get; set; } = new List<ExamPaperSet>();
}
