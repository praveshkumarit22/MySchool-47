using SchoolERP.Application.Attendance.Dtos;
using SchoolERP.Application.Attendance.Requests;

namespace SchoolERP.Application.Attendance.Interfaces;

public interface IAttendanceService
{
    Task<string> MarkAsync(MarkAttendanceRequest request, string markedByUserId, CancellationToken ct);
    Task UpdateAsync(UpdateAttendanceRequest request, CancellationToken ct);
    Task DeleteSessionAsync(string sessionId, CancellationToken ct);

    Task<AttendanceSessionDto?> GetByDateAsync(
        string academicYearId,
        string classId,
        string sectionId,
        DateOnly date,
        CancellationToken ct);
}
