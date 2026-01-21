using SchoolERP.Application.Students.Requests;
using SchoolERP.Domain.Entities.Students;

namespace SchoolERP.Application.Students.Interfaces;

public interface IStudentPromotionService
{
    Task PromoteAsync(PromoteStudentRequest request, CancellationToken ct);

    // Fetch promotion history of a student
    Task<List<StudentPromotionHistory>> GetHistoryAsync(string studentId, CancellationToken ct);
}
