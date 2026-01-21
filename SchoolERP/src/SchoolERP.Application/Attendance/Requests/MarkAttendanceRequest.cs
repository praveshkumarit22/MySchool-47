namespace SchoolERP.Application.Attendance.Requests;

public sealed class MarkAttendanceRequest
{
    public string AcademicYearId { get; set; } = default!;
    public string ClassId { get; set; } = default!;
    public string SectionId { get; set; } = default!;
    public DateOnly Date { get; set; }

    public List<StudentAttendanceItem> Students { get; set; } = [];
}

public sealed class StudentAttendanceItem
{
    public string StudentId { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string? Remarks { get; set; }
}
