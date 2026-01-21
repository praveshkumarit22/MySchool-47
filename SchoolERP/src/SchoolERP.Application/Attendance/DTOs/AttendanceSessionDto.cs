namespace SchoolERP.Application.Attendance.Dtos;

public sealed record AttendanceSessionDto(
    string SessionId,
    string AcademicYearId,
    string ClassId,
    string SectionId,
    DateOnly Date,
    List<StudentAttendanceDto> Students);

public sealed record StudentAttendanceDto(
    string StudentId,
    string Status,
    string? Remarks);
