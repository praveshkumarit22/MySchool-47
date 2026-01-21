namespace SchoolERP.Domain.Entities.Exams;

public class ExamPaperSet
{
    public string Id { get; set; } = default!;
    public string ExamPaperId { get; set; } = default!;
    public string SetName { get; set; } = default!; // A, B, C

    public ICollection<ExamPaperQuestion> Questions { get; set; } = new List<ExamPaperQuestion>();
}
