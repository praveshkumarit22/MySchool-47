using SchoolERP.Application.Exams.Dtos;
using SchoolERP.Application.Exams.Requests;

namespace SchoolERP.Application.Exams.Interfaces;

public interface IResultService
{
    Task GenerateAsync(GenerateResultRequest request, CancellationToken ct);
    Task<StudentMarksheetDto?> GetAsync(string examId, string studentId, CancellationToken ct);
}
