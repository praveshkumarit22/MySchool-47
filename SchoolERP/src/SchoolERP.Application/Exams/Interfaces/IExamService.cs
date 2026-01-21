using SchoolERP.Application.Exams.Dtos;
using SchoolERP.Application.Exams.Requests;

namespace SchoolERP.Application.Exams.Interfaces;

public interface IExamService
{
    Task<string> CreateExamAsync(CreateExamRequest request, CancellationToken ct);
    Task AddSubjectAsync(AddExamSubjectRequest request, CancellationToken ct);
    Task SaveMarksAsync(SaveMarksRequest request, CancellationToken ct);

    Task PublishAsync(string examId, CancellationToken ct);
    Task DeleteAsync(string examId, CancellationToken ct);

    Task<List<ExamDto>> GetAllAsync(string academicYearId, CancellationToken ct);
}
