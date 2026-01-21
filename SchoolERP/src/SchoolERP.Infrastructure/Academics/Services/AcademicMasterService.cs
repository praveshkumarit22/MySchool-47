using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Academics.DTOs;
using SchoolERP.Application.Academics.Interfaces;
using SchoolERP.Application.Academics.Requests;
using SchoolERP.Domain.Entities.Academics;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Academics.Services;

public sealed class AcademicMasterService : IAcademicMasterService
{
    private readonly SchoolDbContext _db;

    public AcademicMasterService(SchoolDbContext db)
    {
        _db = db;
    }

    // ===========================
    // ACADEMIC YEAR
    // ===========================

    public async Task<string> CreateAcademicYearAsync(CreateAcademicYearRequest request, CancellationToken ct)
    {
        var entity = new AcademicYear
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name.Trim(),
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };

        _db.AcademicYears.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity.Id;
    }

    public async Task UpdateAcademicYearAsync(string id, UpdateAcademicYearRequest request, CancellationToken ct)
    {
        var entity = await _db.AcademicYears.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Academic year not found");

        entity.Name = request.Name.Trim();
        entity.StartDate = request.StartDate;
        entity.EndDate = request.EndDate;

        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAcademicYearAsync(string id, CancellationToken ct)
    {
        var entity = await _db.AcademicYears.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Academic year not found");

        entity.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }

    public async Task<List<AcademicYearDto>> GetAcademicYearsAsync(CancellationToken ct)
    {
        return await _db.AcademicYears
            .OrderByDescending(x => x.StartDate)
            .Select(x => new AcademicYearDto(
                x.Id,
                x.Name,
                x.StartDate,
                x.EndDate,
                true
            ))
            .ToListAsync(ct);
    }

    // ===========================
    // CLASSES
    // ===========================

    public async Task<string> CreateClassAsync(CreateSchoolClassRequest request, CancellationToken ct)
    {
        var entity = new SchoolClass
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name.Trim()
        };

        _db.SchoolClasses.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity.Id;
    }

    public async Task UpdateClassAsync(string id, UpdateSchoolClassRequest request, CancellationToken ct)
    {
        var entity = await _db.SchoolClasses.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Class not found");

        entity.Name = request.Name.Trim();
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteClassAsync(string id, CancellationToken ct)
    {
        var entity = await _db.SchoolClasses.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Class not found");

        entity.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }

    public async Task<List<SchoolClassDto>> GetClassesAsync(CancellationToken ct)
    {
        return await _db.SchoolClasses
            .OrderBy(x => x.Name)
            .Select(x => new SchoolClassDto(x.Id, x.Name, 0))
            .ToListAsync(ct);
    }

    // ===========================
    // SECTIONS
    // ===========================

    public async Task<string> CreateSectionAsync(CreateSectionRequest request, CancellationToken ct)
    {
        var entity = new Section
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name.Trim()
        };

        _db.Sections.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity.Id;
    }

    public async Task UpdateSectionAsync(string id, UpdateSectionRequest request, CancellationToken ct)
    {
        var entity = await _db.Sections.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Section not found");

        entity.Name = request.Name.Trim();
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteSectionAsync(string id, CancellationToken ct)
    {
        var entity = await _db.Sections.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Section not found");

        entity.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }

    public async Task<List<SectionDto>> GetSectionsAsync(CancellationToken ct)
    {
        return await _db.Sections
            .OrderBy(x => x.Name)
            .Select(x => new SectionDto(x.Id, x.Name, 0))
            .ToListAsync(ct);
    }

    // ===========================
    // SUBJECTS
    // ===========================

    public async Task<string> CreateSubjectAsync(CreateSubjectRequest request, CancellationToken ct)
    {
        var entity = new Subject
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name.Trim(),
            Code = request.Code
        };

        _db.Subjects.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity.Id;
    }

    public async Task UpdateSubjectAsync(string id, UpdateSubjectRequest request, CancellationToken ct)
    {
        var entity = await _db.Subjects.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Subject not found");

        entity.Name = request.Name.Trim();
        entity.Code = request.Code;
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteSubjectAsync(string id, CancellationToken ct)
    {
        var entity = await _db.Subjects.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Subject not found");

        entity.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }

    public async Task<List<SubjectDto>> GetSubjectsAsync(CancellationToken ct)
    {
        return await _db.Subjects
            .OrderBy(x => x.Name)
            .Select(x => new SubjectDto(x.Id, x.Name, x.Code, false))
            .ToListAsync(ct);
    }

    // ===========================
    // TEACHERS
    // ===========================

    public async Task<string> CreateTeacherAsync(CreateTeacherRequest request, CancellationToken ct)
    {
        var entity = new Teacher
        {
            Id = Guid.NewGuid().ToString(),
            FullName = request.FullName.Trim(),
            Email = request.Email,
            Phone = request.Phone
        };

        _db.Teachers.Add(entity);
        await _db.SaveChangesAsync(ct);
        return entity.Id;
    }

    public async Task UpdateTeacherAsync(string id, UpdateTeacherRequest request, CancellationToken ct)
    {
        var entity = await _db.Teachers.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Teacher not found");

        entity.FullName = request.FullName.Trim();
        entity.Email = request.Email;
        entity.Phone = request.Phone;
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteTeacherAsync(string id, CancellationToken ct)
    {
        var entity = await _db.Teachers.FirstOrDefaultAsync(x => x.Id == id, ct)
            ?? throw new Exception("Teacher not found");

        entity.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }

    public async Task<List<TeacherDto>> GetTeachersAsync(CancellationToken ct)
    {
        return await _db.Teachers
            .OrderBy(x => x.FullName)
            .Select(x => new TeacherDto(x.Id, x.FullName, x.Email, x.Phone))
            .ToListAsync(ct);
    }

    // ===========================
    // CLASS STRUCTURE MAPPING (SOFT DELETE)
    // ===========================

    public async Task AssignSectionToClassAsync(string classId, string sectionId, CancellationToken ct)
    {
        var existing = await _db.ClassSections
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x =>
                x.SchoolClassId == classId &&
                x.SectionId == sectionId, ct);

        if (existing != null)
        {
            if (existing.IsDeleted)
            {
                existing.IsDeleted = false;
                await _db.SaveChangesAsync(ct);
            }
            return;
        }

        _db.ClassSections.Add(new ClassSection
        {
            Id = Guid.NewGuid().ToString(),
            SchoolClassId = classId,
            SectionId = sectionId,
            IsDeleted = false
        });

        await _db.SaveChangesAsync(ct);
    }

    public async Task RemoveSectionFromClassAsync(string classSectionId, CancellationToken ct)
    {
        var entity = await _db.ClassSections.FirstOrDefaultAsync(x => x.Id == classSectionId, ct)
            ?? throw new Exception("Class-Section mapping not found");

        entity.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }

    // -----------------------------------------------------

    public async Task AssignSubjectToClassAsync(string classId, string subjectId, CancellationToken ct)
    {
        var existing = await _db.ClassSubjects
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x =>
                x.SchoolClassId == classId &&
                x.SubjectId == subjectId, ct);

        if (existing != null)
        {
            if (existing.IsDeleted)
            {
                existing.IsDeleted = false;
                await _db.SaveChangesAsync(ct);
            }
            return;
        }

        _db.ClassSubjects.Add(new ClassSubject
        {
            Id = Guid.NewGuid().ToString(),
            SchoolClassId = classId,
            SubjectId = subjectId,
            IsDeleted = false
        });

        await _db.SaveChangesAsync(ct);
    }

    public async Task RemoveSubjectFromClassAsync(string classSubjectId, CancellationToken ct)
    {
        var entity = await _db.ClassSubjects.FirstOrDefaultAsync(x => x.Id == classSubjectId, ct)
            ?? throw new Exception("Class-Subject mapping not found");

        entity.IsDeleted = true;
        await _db.SaveChangesAsync(ct);
    }
}
