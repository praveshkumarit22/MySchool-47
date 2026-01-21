using SchoolERP.Application.Exams.Dtos;
using SchoolERP.Application.Exams.Requests;

namespace SchoolERP.Application.Exams.Interfaces;

public interface IQuestionService
{
    Task<string> CreateAsync(CreateQuestionRequest request, CancellationToken ct);
    Task<List<QuestionDto>> GetAsync(string classId, string subjectId, CancellationToken ct);
    Task DeleteAsync(string id, CancellationToken ct);
}
