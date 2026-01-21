using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Students;

public class StudentHistory : TenantEntity
{
    public string Id { get; set; } = default!;

    public string StudentId { get; set; } = default!;
    public string AcademicYearId { get; set; } = default!;
    public string ClassId { get; set; } = default!;
    public string SectionId { get; set; } = default!;

    public string RollNumber { get; set; } = default!;
    public string FinalStatus { get; set; } = default!; // Promoted | Completed | Left

    public DateTime ArchivedOn { get; set; } = DateTime.UtcNow;

    public Student Student { get; set; } = default!;
}
