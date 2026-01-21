using SchoolERP.Application.Students.Requests;

namespace SchoolERP.Application.Students.Interfaces;

public interface IStudentAdmissionService
{
    Task<string> AdmitAsync(CreateStudentAdmissionRequest request, CancellationToken ct);
}
