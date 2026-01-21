using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Application.Exams.Requests;
using SchoolERP.Domain.Entities.Exams;
using SchoolERP.Infrastructure.Data;

public sealed class PaperBuilderService : IPaperBuilderService
{
    private readonly SchoolDbContext _db;
    public PaperBuilderService(SchoolDbContext db) => _db = db;

    public async Task<string> CreatePaperAsync(CreatePaperRequest r, CancellationToken ct)
    {
        var p = new ExamPaper
        {
            Id = Guid.NewGuid().ToString(),
            ExamId = r.ExamId,
            SubjectId = r.SubjectId,
            MaxMarks = r.MaxMarks,
            DurationMinutes = r.DurationMinutes
        };

        _db.ExamPapers.Add(p);
        await _db.SaveChangesAsync(ct);
        return p.Id;
    }

    public async Task<string> CreatePaperSetAsync(CreatePaperSetRequest r, CancellationToken ct)
    {
        var set = new ExamPaperSet
        {
            Id = Guid.NewGuid().ToString(),
            ExamPaperId = r.ExamPaperId,
            SetName = r.SetName
        };

        _db.ExamPaperSets.Add(set);
        await _db.SaveChangesAsync(ct);
        return set.Id;
    }

    public async Task AddQuestionAsync(AddQuestionToPaperRequest r, CancellationToken ct)
    {
        _db.ExamPaperQuestions.Add(new ExamPaperQuestion
        {
            Id = Guid.NewGuid().ToString(),
            ExamPaperSetId = r.PaperSetId,
            QuestionId = r.QuestionId,
            QuestionNo = r.QuestionNo,
            Marks = r.Marks
        });

        await _db.SaveChangesAsync(ct);
    }
}
