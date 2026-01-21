namespace SchoolERP.Application.Attendance.Requests;

public sealed class UpdateAttendanceRequest
{
    public string SessionId { get; set; } = default!;
    public List<StudentAttendanceItem> Students { get; set; } = [];
}
