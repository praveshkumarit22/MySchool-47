using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Students.Interfaces;
using SchoolERP.Application.Students.Requests;
using SchoolERP.Domain.Entities.Students;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Students.Services;

public sealed class StudentEnrollmentService : IStudentEnrollmentService
{
    private readonly SchoolDbContext _db;

    public StudentEnrollmentService(SchoolDbContext db)
    {
        _db = db;
    }

    public async Task EnrollAsync(EnrollStudentRequest request, CancellationToken ct)
    {
        // Validate student exists
        var student = await _db.Students
            .Include(x => x.Enrollments)
            .FirstOrDefaultAsync(x => x.Id == request.StudentId, ct);

        if (student == null)
            throw new InvalidOperationException("Student not found");

        // Prevent duplicate enrollment in same academic year
        if (student.Enrollments.Any(x => x.AcademicYearId == request.AcademicYearId))
            throw new InvalidOperationException("Student already enrolled in this academic year");

        // Get / create roll series
        var series = await _db.StudentRollSeries
            .FirstOrDefaultAsync(x =>
                x.AcademicYearId == request.AcademicYearId &&
                x.ClassId == request.ClassId &&
                x.SectionId == request.SectionId, ct);

        if (series == null)
        {
            series = new StudentRollSeries
            {
                Id = Guid.NewGuid().ToString(),
                AcademicYearId = request.AcademicYearId,
                ClassId = request.ClassId,
                SectionId = request.SectionId,
                CurrentRoll = 0
            };

            _db.StudentRollSeries.Add(series);
        }

        series.CurrentRoll++;

        // Create enrollment
        student.Enrollments.Add(new StudentEnrollment
        {
            Id = Guid.NewGuid().ToString(),
            AcademicYearId = request.AcademicYearId,
            ClassId = request.ClassId,
            SectionId = request.SectionId,
            RollNumber = series.CurrentRoll,
            Status = "Active"
        });

        await _db.SaveChangesAsync(ct);
    }
}
