using SchoolERP.Application.Students.Requests;

namespace SchoolERP.Application.Students.Interfaces;

public interface IStudentEnrollmentService
{
    Task EnrollAsync(EnrollStudentRequest request, CancellationToken ct);
}
