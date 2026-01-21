using SchoolERP.Application.Common.Exceptions;
using SchoolERP.Application.Exams.Dtos;
using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Application.Exams.Requests;
using SchoolERP.Domain.Entities.Exams;
using SchoolERP.Infrastructure.Data;

public sealed class QuestionService : IQuestionService
{
    private readonly SchoolDbContext _db;
    public QuestionService(SchoolDbContext db) => _db = db;

    public async Task<string> CreateAsync(CreateQuestionRequest r, CancellationToken ct)
    {
        var q = new Question
        {
            Id = Guid.NewGuid().ToString(),
            ClassId = r.ClassId,
            SubjectId = r.SubjectId,
            Text = r.Text,
            Type = r.Type,
            DefaultMarks = r.DefaultMarks
        };

        if (r.Options is not null)
        {
            foreach (var o in r.Options)
                q.Options.Add(new QuestionOption
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = o.Text,
                    IsCorrect = o.IsCorrect
                });
        }

        _db.Questions.Add(q);
        await _db.SaveChangesAsync(ct);
        return q.Id;
    }

    public async Task<List<QuestionDto>> GetAsync(string classId, string subjectId, CancellationToken ct)
    {
        return await _db.Questions
            .Where(x => x.ClassId == classId && x.SubjectId == subjectId)
            .Select(x => new QuestionDto(
                x.Id,
                x.Text,
                x.Type,
                x.DefaultMarks))
            .ToListAsync(ct);
    }

    public async Task DeleteAsync(string id, CancellationToken ct)
    {
        var q = await _db.Questions.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (q is null) throw new NotFoundException("Question not found");
        q.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }
}
