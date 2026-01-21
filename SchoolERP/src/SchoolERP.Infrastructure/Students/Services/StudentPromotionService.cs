using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Students.Interfaces;
using SchoolERP.Application.Students.Requests;
using SchoolERP.Domain.Entities.Students;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Students.Services;

public sealed class StudentPromotionService : IStudentPromotionService
{
    private readonly SchoolDbContext _db;

    public StudentPromotionService(SchoolDbContext db)
    {
        _db = db;
    }
    public async Task<List<StudentPromotionHistory>> GetHistoryAsync(string studentId, CancellationToken ct)
    {
        return await _db.StudentPromotionHistory
            .Where(x => x.StudentId == studentId)
            .OrderByDescending(x => x.PromotedOn)
            .ToListAsync(ct);
    }

    public async Task PromoteAsync(PromoteStudentRequest request, CancellationToken ct)
    {
        var student = await _db.Students
            .Include(x => x.Enrollments)
            .FirstOrDefaultAsync(x => x.Id == request.StudentId, ct);

        if (student == null)
            throw new InvalidOperationException("Student not found");

        // find active enrollment
        var current = student.Enrollments.FirstOrDefault(x =>
            x.AcademicYearId == request.FromAcademicYearId &&
            x.ClassId == request.FromClassId &&
            x.SectionId == request.FromSectionId &&
            x.Status == "Active");

        if (current == null)
            throw new InvalidOperationException("Active enrollment not found");

        // close old enrollment
        current.Status = "Completed";

        // Passout / TC flow (no new enrollment)
        if (request.IsPassout || request.IsTc)
        {
            var newStatus = request.IsPassout ? "Passout" : "TC";

            student.Status = newStatus;

            _db.StudentStatusHistory.Add(new StudentStatusHistory
            {
                Id = Guid.NewGuid().ToString(),
                StudentId = student.Id,
                OldStatus = "Active",
                NewStatus = newStatus,
                ChangedOn = DateTime.UtcNow,
                Reason = request.Remarks
            });

            await _db.SaveChangesAsync(ct);
            return;
        }

        // normal promotion → create new enrollment
        var newEnrollment = await CreateNewEnrollment(student, request, ct);

        // promotion history (corrected to your entity)
        _db.StudentPromotionHistory.Add(new StudentPromotionHistory
        {
            Id = Guid.NewGuid().ToString(),
            StudentId = student.Id,
            FromEnrollmentId = current.Id,
            ToEnrollmentId = newEnrollment.Id,
            PromotedOn = DateTime.UtcNow,
            Remarks = request.Remarks ?? "Promoted"
        });

        await _db.SaveChangesAsync(ct);
    }

    private async Task<StudentEnrollment> CreateNewEnrollment(
        Student student,
        PromoteStudentRequest request,
        CancellationToken ct)
    {
        var series = await _db.StudentRollSeries.FirstOrDefaultAsync(x =>
            x.AcademicYearId == request.ToAcademicYearId &&
            x.ClassId == request.ToClassId &&
            x.SectionId == request.ToSectionId, ct);

        if (series == null)
        {
            series = new StudentRollSeries
            {
                Id = Guid.NewGuid().ToString(),
                AcademicYearId = request.ToAcademicYearId,
                ClassId = request.ToClassId,
                SectionId = request.ToSectionId,
                CurrentRoll = 0
            };

            _db.StudentRollSeries.Add(series);
        }

        series.CurrentRoll++;

        var enrollment = new StudentEnrollment
        {
            Id = Guid.NewGuid().ToString(),
            AcademicYearId = request.ToAcademicYearId,
            ClassId = request.ToClassId,
            SectionId = request.ToSectionId,
            RollNumber = series.CurrentRoll,
            Status = "Active"
        };

        student.Enrollments.Add(enrollment);

        return enrollment;
    }
}
