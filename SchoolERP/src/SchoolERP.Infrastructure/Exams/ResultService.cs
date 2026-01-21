using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Common.Exceptions;
using SchoolERP.Application.Exams.Dtos;
using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Application.Exams.Requests;
using SchoolERP.Domain.Entities.Exams;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Exams;

public sealed class ResultService : IResultService
{
    private readonly SchoolDbContext _db;
    public ResultService(SchoolDbContext db) => _db = db;

    public async Task GenerateAsync(GenerateResultRequest r, CancellationToken ct)
    {
        var exam = await _db.Exams
            .Include(x => x.Subjects)
                .ThenInclude(x => x.Marks)
            .FirstOrDefaultAsync(x => x.Id == r.ExamId, ct);

        if (exam is null || exam.Status != "Published")
            throw new ValidationException("Exam not published.");

        var marks = exam.Subjects
            .SelectMany(x => x.Marks)
            .Where(x => x.StudentId == r.StudentId)
            .ToList();

        if (!marks.Any())
            throw new NotFoundException("Marks not found.");

        var total = exam.Subjects.Sum(x => x.MaxMarks);
        var obtained = marks.Where(x => !x.IsAbsent).Sum(x => x.ObtainedMarks);

        var result = new StudentResult
        {
            Id = Guid.NewGuid().ToString(),
            StudentId = r.StudentId,
            ExamId = r.ExamId,
            TotalMarks = total,
            ObtainedMarks = obtained,
            Percentage = total == 0 ? 0 : Math.Round((obtained / total) * 100, 2),
            ResultStatus = "Generated"
        };

        foreach (var s in exam.Subjects)
        {
            var m = marks.FirstOrDefault(x => x.ExamSubjectId == s.Id);

            result.Subjects.Add(new StudentResultSubject
            {
                Id = Guid.NewGuid().ToString(),
                SubjectId = s.SubjectId,
                MaxMarks = s.MaxMarks,
                ObtainedMarks = m?.ObtainedMarks ?? 0,
                IsAbsent = m?.IsAbsent ?? true,
                Grade = m?.Grade
            });
        }

        _db.StudentResults.Add(result);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<StudentMarksheetDto?> GetAsync(string examId, string studentId, CancellationToken ct)
    {
        return await _db.StudentResults
            .Include(x => x.Subjects)
            .Where(x => x.ExamId == examId && x.StudentId == studentId)
            .Select(x => new StudentMarksheetDto(
                x.StudentId,
                x.ExamId,
                x.TotalMarks,
                x.ObtainedMarks,
                x.Percentage,
                x.ResultStatus,
                x.Subjects.Select(s => new StudentMarksheetSubjectDto(
                    s.SubjectId,
                    s.MaxMarks,
                    s.ObtainedMarks,
                    s.IsAbsent,
                    s.Grade)).ToList()))
            .FirstOrDefaultAsync(ct);
    }
}
