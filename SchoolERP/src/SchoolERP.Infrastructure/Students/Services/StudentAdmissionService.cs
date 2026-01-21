using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Students.Interfaces;
using SchoolERP.Application.Students.Requests;
using SchoolERP.Domain.Entities.Students;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Students.Services;

public sealed class StudentAdmissionService : IStudentAdmissionService
{
    private readonly SchoolDbContext _db;

    public StudentAdmissionService(SchoolDbContext db)
    {
        _db = db;
    }

    public async Task<string> AdmitAsync(CreateStudentAdmissionRequest request, CancellationToken ct)
    {
        // Generate admission number (can later be moved to series engine)
        var admissionNo = $"ADM-{DateTime.UtcNow:yyyyMMddHHmmssfff}";

        var student = new Student
        {
            Id = Guid.NewGuid().ToString(),
            AdmissionNo = admissionNo,
            Status = "Active",
            Profile = new StudentProfile
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                BloodGroup = request.BloodGroup,
                AddressLine1 = request.AddressLine1,
                AddressLine2 = request.AddressLine2,
                City = request.City,
                State = request.State,
                Pincode = request.Pincode
            }
        };

        // Guardians
        foreach (var g in request.Guardians)
        {
            student.Guardians.Add(new StudentGuardian
            {
                Id = Guid.NewGuid().ToString(),
                FullName = g.FullName,
                Relation = g.Relation,
                Phone = g.Phone,
                Email = g.Email,
                Occupation = g.Occupation
            });
        }

        // Initial enrollment
        student.Enrollments.Add(new StudentEnrollment
        {
            Id = Guid.NewGuid().ToString(),
            AcademicYearId = request.AcademicYearId,
            ClassId = request.ClassId,
            SectionId = request.SectionId,
            Status = "Active",
            RollNumber = 0 // assigned by enrollment engine
        });

        _db.Students.Add(student);
        await _db.SaveChangesAsync(ct);

        return student.Id;
    }
}
