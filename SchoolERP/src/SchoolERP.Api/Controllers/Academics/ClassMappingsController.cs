using Microsoft.AspNetCore.Mvc;
using SchoolERP.Api.Models;
using SchoolERP.Application.Academics.Interfaces;

namespace SchoolERP.Api.Controllers.Academics;

[ApiController]
[Route("api/academics/mappings")]
public sealed class ClassMappingsController : ControllerBase
{
    private readonly IAcademicMasterService _service;

    public ClassMappingsController(IAcademicMasterService service)
    {
        _service = service;
    }

    // =====================================================
    // CLASS ↔ SECTION
    // =====================================================

    [HttpPost("class/{classId}/section/{sectionId}")]
    public async Task<ApiResponse<string>> AssignSection(
        string classId,
        string sectionId,
        CancellationToken ct)
    {
        await _service.AssignSectionToClassAsync(classId, sectionId, ct);
        return ApiResponse<string>.Ok("OK", "Section assigned to class");
    }

    // IMPORTANT:
    // We delete by mappingId, not by classId+sectionId
    // because ERP systems must preserve history & avoid ambiguity.
    [HttpDelete("class-section/{classSectionId}")]
    public async Task<ApiResponse<string>> RemoveSection(
        string classSectionId,
        CancellationToken ct)
    {
        await _service.RemoveSectionFromClassAsync(classSectionId, ct);
        return ApiResponse<string>.Ok("OK", "Section removed from class");
    }

    // =====================================================
    // CLASS ↔ SUBJECT
    // =====================================================

    [HttpPost("class/{classId}/subject/{subjectId}")]
    public async Task<ApiResponse<string>> AssignSubject(
        string classId,
        string subjectId,
        CancellationToken ct)
    {
        await _service.AssignSubjectToClassAsync(classId, subjectId, ct);
        return ApiResponse<string>.Ok("OK", "Subject assigned to class");
    }

    // IMPORTANT:
    // Soft delete by mappingId (not by both ids)
    [HttpDelete("class-subject/{classSubjectId}")]
    public async Task<ApiResponse<string>> RemoveSubject(
        string classSubjectId,
        CancellationToken ct)
    {
        await _service.RemoveSubjectFromClassAsync(classSubjectId, ct);
        return ApiResponse<string>.Ok("OK", "Subject removed from class");
    }
}
