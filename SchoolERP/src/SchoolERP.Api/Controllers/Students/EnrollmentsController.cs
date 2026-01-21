using SchoolERP.Application.Students.Interfaces;
using SchoolERP.Application.Students.Requests;

namespace SchoolERP.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/enrollments")]
public sealed class EnrollmentsController : ControllerBase
{
    private readonly IStudentEnrollmentService _service;

    public EnrollmentsController(IStudentEnrollmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Enroll(
        EnrollStudentRequest request,
        CancellationToken ct)
    {
         await _service.EnrollAsync(request, ct);
        return Ok(new { message = "Student promoted successfully" });
    }
}
