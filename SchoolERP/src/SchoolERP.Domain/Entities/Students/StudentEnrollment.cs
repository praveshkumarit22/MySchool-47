using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Students;

public class StudentEnrollment : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;
    public string StudentId { get; set; } = default!;

    public string AcademicYearId { get; set; } = default!;
    public string ClassId { get; set; } = default!;
    public string SectionId { get; set; } = default!;

    public int RollNumber { get; set; }
    public string Status { get; set; } = "Enrolled"; // Enrolled | Promoted | Repeated | Left

    public DateOnly EnrollmentDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public DateOnly? ExitDate { get; set; }

    public bool IsDeleted { get; set; }

    public Student Student { get; set; } = default!;
}
