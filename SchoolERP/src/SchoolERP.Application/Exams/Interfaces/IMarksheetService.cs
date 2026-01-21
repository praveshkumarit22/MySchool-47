namespace SchoolERP.Application.Exams.Interfaces;

public interface IMarksheetService
{
    Task<string> GenerateHtmlAsync(string examId, string studentId, CancellationToken ct);
    Task<byte[]> GeneratePdfAsync(string examId, string studentId, CancellationToken ct);
}
