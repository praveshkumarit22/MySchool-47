using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Common.Exceptions;
using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Infrastructure.Data;
using System.Text;

namespace SchoolERP.Infrastructure.Exams;

public sealed class MarksheetService : IMarksheetService
{
    private readonly SchoolDbContext _db;

    public MarksheetService(SchoolDbContext db)
    {
        _db = db;
    }

    public async Task<string> GenerateHtmlAsync(string examId, string studentId, CancellationToken ct)
    {
        var result = await _db.StudentResults
            .Include(x => x.Subjects)
            .FirstOrDefaultAsync(x => x.ExamId == examId && x.StudentId == studentId, ct);

        if (result is null) throw new NotFoundException("Result not found.");

        var template = await _db.MarksheetTemplates
            .FirstOrDefaultAsync(x => x.IsDefault, ct);

        if (template is null) throw new NotFoundException("Marksheet template missing.");

        var sb = new StringBuilder();
        sb.Append(template.HeaderHtml);
        sb.Append(template.BodyHtml);
        sb.Append(template.FooterHtml);

        // later: replace placeholders with student/exam data

        return sb.ToString();
    }

    public async Task<byte[]> GeneratePdfAsync(string examId, string studentId, CancellationToken ct)
    {
        var html = await GenerateHtmlAsync(examId, studentId, ct);

        // recommended: Playwright / QuestPDF
        // placeholder: return HTML bytes for now

        return Encoding.UTF8.GetBytes(html);
    }
}
