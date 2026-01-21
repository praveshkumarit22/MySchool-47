namespace SchoolERP.Domain.Entities.Attendance;

public class StudentAttendance
{
    public string Id { get; set; } = default!;

    public string AttendanceSessionId { get; set; } = default!;
    public string StudentId { get; set; } = default!;

    public string Status { get; set; } = default!;
    // Present | Absent | Late | Leave

    public string? Remarks { get; set; }

    public AttendanceSession AttendanceSession { get; set; } = default!;
}
