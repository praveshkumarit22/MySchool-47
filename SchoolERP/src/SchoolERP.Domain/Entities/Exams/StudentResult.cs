using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Exams;

public class StudentResult : TenantEntity
{
    public string Id { get; set; } = default!;
    public string StudentId { get; set; } = default!;
    public string ExamId { get; set; } = default!;

    public decimal TotalMarks { get; set; }
    public decimal ObtainedMarks { get; set; }
    public decimal Percentage { get; set; }
    public string ResultStatus { get; set; } = default!; // Pass | Fail | Generated

    public DateTime GeneratedOn { get; set; } = DateTime.UtcNow;

    public ICollection<StudentResultSubject> Subjects { get; set; } = new List<StudentResultSubject>();
}
