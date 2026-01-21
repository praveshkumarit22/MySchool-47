using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Attendance.Dtos;
using SchoolERP.Application.Attendance.Interfaces;
using SchoolERP.Application.Attendance.Requests;
using SchoolERP.Application.Common.Exceptions;
using SchoolERP.Domain.Entities.Attendance;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Attendance;

public sealed class AttendanceService : IAttendanceService
{
    private readonly SchoolDbContext _db;

    public AttendanceService(SchoolDbContext db)
    {
        _db = db;
    }

    public async Task<string> MarkAsync(
        MarkAttendanceRequest request,
        string markedByUserId,
        CancellationToken ct)
    {
        // prevent duplicate daily attendance
        var exists = await _db.AttendanceSessions.AnyAsync(x =>
            x.AcademicYearId == request.AcademicYearId &&
            x.ClassId == request.ClassId &&
            x.SectionId == request.SectionId &&
            x.Date == request.Date, ct);

        if (exists)
            throw new ValidationException("Attendance already marked for this date.");

        var session = new AttendanceSession
        {
            Id = Guid.NewGuid().ToString(),
            AcademicYearId = request.AcademicYearId,
            ClassId = request.ClassId,
            SectionId = request.SectionId,
            Date = request.Date,
            MarkedByUserId = markedByUserId
        };

        foreach (var s in request.Students)
        {
            session.Students.Add(new StudentAttendance
            {
                Id = Guid.NewGuid().ToString(),
                StudentId = s.StudentId,
                Status = s.Status,
                Remarks = s.Remarks
            });
        }

        _db.AttendanceSessions.Add(session);
        await _db.SaveChangesAsync(ct);

        return session.Id;
    }

    public async Task UpdateAsync(UpdateAttendanceRequest request, CancellationToken ct)
    {
        var session = await _db.AttendanceSessions
            .Include(x => x.Students)
            .FirstOrDefaultAsync(x => x.Id == request.SessionId, ct);

        if (session is null)
            throw new NotFoundException("Attendance session not found.");

        session.Students.Clear();

        foreach (var s in request.Students)
        {
            session.Students.Add(new StudentAttendance
            {
                Id = Guid.NewGuid().ToString(),
                AttendanceSessionId = session.Id,
                StudentId = s.StudentId,
                Status = s.Status,
                Remarks = s.Remarks
            });
        }

        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteSessionAsync(string sessionId, CancellationToken ct)
    {
        var session = await _db.AttendanceSessions.FirstOrDefaultAsync(x => x.Id == sessionId, ct);

        if (session is null)
            throw new NotFoundException("Attendance session not found.");

        session.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }

    public async Task<AttendanceSessionDto?> GetByDateAsync(
        string academicYearId,
        string classId,
        string sectionId,
        DateOnly date,
        CancellationToken ct)
    {
        return await _db.AttendanceSessions
            .Include(x => x.Students)
            .Where(x =>
                x.AcademicYearId == academicYearId &&
                x.ClassId == classId &&
                x.SectionId == sectionId &&
                x.Date == date)
            .Select(x => new AttendanceSessionDto(
                x.Id,
                x.AcademicYearId,
                x.ClassId,
                x.SectionId,
                x.Date,
                x.Students.Select(s => new StudentAttendanceDto(
                    s.StudentId,
                    s.Status,
                    s.Remarks)).ToList()))
            .FirstOrDefaultAsync(ct);
    }
}
