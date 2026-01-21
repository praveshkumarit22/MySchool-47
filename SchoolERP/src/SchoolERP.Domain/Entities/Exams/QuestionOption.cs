namespace SchoolERP.Domain.Entities.Exams;

public class QuestionOption
{
    public string Id { get; set; } = default!;
    public string QuestionId { get; set; } = default!;

    public string Text { get; set; } = default!;
    public bool IsCorrect { get; set; }

    public Question Question { get; set; } = default!;
}
