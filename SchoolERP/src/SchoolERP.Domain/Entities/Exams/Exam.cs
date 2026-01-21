using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Exams;

public class Exam : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;

    public string AcademicYearId { get; set; } = default!;
    public string Name { get; set; } = default!;       // Unit Test 1, Mid Term
    public string Term { get; set; } = default!;       // Term-1, Term-2
    public string Status { get; set; } = "Draft";      // Draft | Published

    public string ClassId { get; set; } = default!;
    public string SectionId { get; set; } = default!;

    public bool IsDeleted { get; set; }

    public ICollection<ExamSubject> Subjects { get; set; } = new List<ExamSubject>();
}
