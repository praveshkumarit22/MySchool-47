using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Attendance;

public class AttendanceSession : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;

    public string AcademicYearId { get; set; } = default!;
    public string ClassId { get; set; } = default!;
    public string SectionId { get; set; } = default!;

    public DateOnly Date { get; set; }

    public string MarkedByUserId { get; set; } = default!;
    public DateTime MarkedAt { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; }

    public ICollection<StudentAttendance> Students { get; set; } = new List<StudentAttendance>();
}
