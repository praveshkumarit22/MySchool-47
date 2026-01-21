namespace SchoolERP.Domain.Entities.Exams;

public class ExamPaperQuestion
{
    public string Id { get; set; } = default!;
    public string ExamPaperSetId { get; set; } = default!;
    public string QuestionId { get; set; } = default!;

    public int QuestionNo { get; set; }
    public decimal Marks { get; set; }

    public Question Question { get; set; } = default!;
}
