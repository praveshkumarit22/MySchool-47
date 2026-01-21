using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Students.Interfaces;
using SchoolERP.Application.Students.Requests;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Api.Controllers;

[ApiController]
[Route("api/students")]
public sealed class StudentsController : ControllerBase
{
    private readonly IStudentAdmissionService _admissionService;
    private readonly IStudentEnrollmentService _enrollmentService;
    private readonly IStudentPromotionService _promotionService;
    private readonly SchoolDbContext _db;

    public StudentsController(
        IStudentAdmissionService admissionService,
        IStudentEnrollmentService enrollmentService,
        IStudentPromotionService promotionService,
        SchoolDbContext db)
    {
        _admissionService = admissionService;
        _enrollmentService = enrollmentService;
        _promotionService = promotionService;
        _db = db;
    }

    // ============================
    // ADMISSION
    // ============================

    [HttpPost("admit")]
    public async Task<IActionResult> Admit(
        [FromBody] CreateStudentAdmissionRequest request,
        CancellationToken ct)
    {
        var studentId = await _admissionService.AdmitAsync(request, ct);
        return Ok(new { studentId });
    }

    // ============================
    // ENROLLMENT
    // ============================

    [HttpPost("enroll")]
    public async Task<IActionResult> Enroll(
        [FromBody] EnrollStudentRequest request,
        CancellationToken ct)
    {
        await _enrollmentService.EnrollAsync(request, ct);
        return Ok(new { message = "Student enrolled successfully" });
    }

    // ============================
    // PROMOTION
    // ============================

    [HttpPost("promote")]
    public async Task<IActionResult> Promote(
        [FromBody] PromoteStudentRequest request,
        CancellationToken ct)
    {
        await _promotionService.PromoteAsync(request, ct);
        return Ok(new { message = "Student promotion completed" });
    }

    [HttpGet("{studentId}/promotion-history")]
    public async Task<IActionResult> PromotionHistory(
        string studentId,
        CancellationToken ct)
    {
        var history = await _promotionService.GetHistoryAsync(studentId, ct);
        return Ok(history);
    }

    // ============================
    // QUERIES (READ SIDE)
    // ============================

    [HttpGet("{studentId}")]
    public async Task<IActionResult> GetStudent(string studentId, CancellationToken ct)
    {
        var student = await _db.Students
            .Include(x => x.Profile)
            .Include(x => x.Guardians)
            .Include(x => x.Enrollments)
            .FirstOrDefaultAsync(x => x.Id == studentId, ct);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpGet("{studentId}/enrollments")]
    public async Task<IActionResult> GetEnrollments(string studentId, CancellationToken ct)
    {
        var enrollments = await _db.StudentEnrollments
            .Where(x => x.StudentId == studentId)
            .OrderByDescending(x => x.AcademicYearId)
            .ToListAsync(ct);

        return Ok(enrollments);
    }
}
