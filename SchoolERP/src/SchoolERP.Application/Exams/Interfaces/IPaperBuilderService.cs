using SchoolERP.Application.Exams.Requests;

namespace SchoolERP.Application.Exams.Interfaces;

public interface IPaperBuilderService
{
    Task<string> CreatePaperAsync(CreatePaperRequest request, CancellationToken ct);
    Task<string> CreatePaperSetAsync(CreatePaperSetRequest request, CancellationToken ct);
    Task AddQuestionAsync(AddQuestionToPaperRequest request, CancellationToken ct);
}
