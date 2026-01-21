using SchoolERP.Application.Academics.DTOs;
using SchoolERP.Application.Academics.Requests;

namespace SchoolERP.Application.Academics.Interfaces;

public interface IAcademicMasterService
{
    // ===========================
    // Academic Year
    // ===========================
    Task<string> CreateAcademicYearAsync(CreateAcademicYearRequest request, CancellationToken ct);
    Task UpdateAcademicYearAsync(string id, UpdateAcademicYearRequest request, CancellationToken ct);
    Task DeleteAcademicYearAsync(string id, CancellationToken ct);
    Task<List<AcademicYearDto>> GetAcademicYearsAsync(CancellationToken ct);

    // ===========================
    // Classes
    // ===========================
    Task<string> CreateClassAsync(CreateSchoolClassRequest request, CancellationToken ct);
    Task UpdateClassAsync(string id, UpdateSchoolClassRequest request, CancellationToken ct);
    Task DeleteClassAsync(string id, CancellationToken ct);
    Task<List<SchoolClassDto>> GetClassesAsync(CancellationToken ct);

    // ===========================
    // Sections
    // ===========================
    Task<string> CreateSectionAsync(CreateSectionRequest request, CancellationToken ct);
    Task UpdateSectionAsync(string id, UpdateSectionRequest request, CancellationToken ct);
    Task DeleteSectionAsync(string id, CancellationToken ct);
    Task<List<SectionDto>> GetSectionsAsync(CancellationToken ct);

    // ===========================
    // Subjects
    // ===========================
    Task<string> CreateSubjectAsync(CreateSubjectRequest request, CancellationToken ct);
    Task UpdateSubjectAsync(string id, UpdateSubjectRequest request, CancellationToken ct);
    Task DeleteSubjectAsync(string id, CancellationToken ct);
    Task<List<SubjectDto>> GetSubjectsAsync(CancellationToken ct);

    // ===========================
    // Teachers
    // ===========================
    Task<string> CreateTeacherAsync(CreateTeacherRequest request, CancellationToken ct);
    Task UpdateTeacherAsync(string id, UpdateTeacherRequest request, CancellationToken ct);
    Task DeleteTeacherAsync(string id, CancellationToken ct);
    Task<List<TeacherDto>> GetTeachersAsync(CancellationToken ct);

    // ===========================
    // Class Structure Mapping
    // ===========================
    Task AssignSectionToClassAsync(string classId, string sectionId, CancellationToken ct);
    Task RemoveSectionFromClassAsync(string classSectionId, CancellationToken ct);

    Task AssignSubjectToClassAsync(string classId, string subjectId, CancellationToken ct);
    Task RemoveSubjectFromClassAsync(string classSubjectId, CancellationToken ct);
}
