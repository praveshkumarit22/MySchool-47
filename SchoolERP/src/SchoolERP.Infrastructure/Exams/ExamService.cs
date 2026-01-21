using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Common.Exceptions;
using SchoolERP.Application.Exams.Dtos;
using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Application.Exams.Requests;
using SchoolERP.Domain.Entities.Exams;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Exams;

public sealed class ExamService : IExamService
{
    private readonly SchoolDbContext _db;

    public ExamService(SchoolDbContext db)
    {
        _db = db;
    }

    public async Task<string> CreateExamAsync(CreateExamRequest request, CancellationToken ct)
    {
        var exam = new Exam
        {
            Id = Guid.NewGuid().ToString(),
            AcademicYearId = request.AcademicYearId,
            Name = request.Name,
            Term = request.Term
        };

        _db.Exams.Add(exam);
        await _db.SaveChangesAsync(ct);

        return exam.Id;
    }

    public async Task AddSubjectAsync(AddExamSubjectRequest request, CancellationToken ct)
    {
        var exists = await _db.ExamSubjects.AnyAsync(x =>
            x.ExamId == request.ExamId &&
            x.SubjectId == request.SubjectId, ct);

        if (exists)
            throw new ValidationException("Subject already added.");

        _db.ExamSubjects.Add(new ExamSubject
        {
            Id = Guid.NewGuid().ToString(),
            ExamId = request.ExamId,
            SubjectId = request.SubjectId,
            MaxMarks = request.MaxMarks,
            ExamDate = request.ExamDate
        });

        await _db.SaveChangesAsync(ct);
    }

    public async Task SaveMarksAsync(SaveMarksRequest request, CancellationToken ct)
    {
        var exam = await _db.ExamSubjects
            .Include(x => x.Exam)
            .FirstOrDefaultAsync(x => x.Id == request.ExamSubjectId, ct);

        if (exam is null)
            throw new NotFoundException("Exam subject not found.");

        if (exam.Exam.Status == "Published")
            throw new ValidationException("Marks cannot be modified after publish.");

        var old = _db.StudentMarks.Where(x => x.ExamSubjectId == request.ExamSubjectId);
        _db.StudentMarks.RemoveRange(old);

        foreach (var s in request.Students)
        {
            _db.StudentMarks.Add(new StudentMark
            {
                Id = Guid.NewGuid().ToString(),
                ExamSubjectId = request.ExamSubjectId,
                StudentId = s.StudentId,
                ObtainedMarks = s.ObtainedMarks,
                Grade = s.Grade,
                Remarks = s.Remarks
            });
        }

        await _db.SaveChangesAsync(ct);
    }

    public async Task PublishAsync(string examId, CancellationToken ct)
    {
        var exam = await _db.Exams.FirstOrDefaultAsync(x => x.Id == examId, ct);
        if (exam is null) throw new NotFoundException("Exam not found.");

        exam.Status = "Published";
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(string examId, CancellationToken ct)
    {
        var exam = await _db.Exams.FirstOrDefaultAsync(x => x.Id == examId, ct);
        if (exam is null) throw new NotFoundException("Exam not found.");

        exam.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }

    public async Task<List<ExamDto>> GetAllAsync(string academicYearId, CancellationToken ct)
    {
        return await _db.Exams
            .Where(x => x.AcademicYearId == academicYearId)
            .Select(x => new ExamDto(x.Id, x.Name, x.Term, x.Status))
            .ToListAsync(ct);
    }
}
