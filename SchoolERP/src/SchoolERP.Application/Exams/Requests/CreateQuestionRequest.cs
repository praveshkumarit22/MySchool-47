namespace SchoolERP.Application.Exams.Requests;

public sealed class CreateQuestionRequest
{
    public string ClassId { get; set; } = default!;
    public string SubjectId { get; set; } = default!;
    public string Text { get; set; } = default!;
    public string Type { get; set; } = "MCQ";
    public decimal DefaultMarks { get; set; }
    public List<CreateQuestionOption>? Options { get; set; }
}

public sealed class CreateQuestionOption
{
    public string Text { get; set; } = default!;
    public bool IsCorrect { get; set; }
}
