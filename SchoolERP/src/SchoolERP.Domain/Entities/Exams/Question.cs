using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Exams;

public class Question : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;
    public string ClassId { get; set; } = default!;
    public string SubjectId { get; set; } = default!;

    public string Text { get; set; } = default!;
    public string Type { get; set; } = "MCQ"; // MCQ | Descriptive
    public decimal DefaultMarks { get; set; }
    public string Difficulty { get; set; } = "Medium";

    public bool IsDeleted { get; set; }

    public ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();
}
