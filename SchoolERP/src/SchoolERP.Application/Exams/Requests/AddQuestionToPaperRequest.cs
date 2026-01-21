namespace SchoolERP.Application.Exams.Requests;

public sealed class AddQuestionToPaperRequest
{
    public string PaperSetId { get; set; } = default!;
    public string QuestionId { get; set; } = default!;
    public int QuestionNo { get; set; }
    public decimal Marks { get; set; }
}
