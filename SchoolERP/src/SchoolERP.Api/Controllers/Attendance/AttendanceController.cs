using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.Application.Attendance.Interfaces;
using SchoolERP.Application.Attendance.Requests;

namespace SchoolERP.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/attendance")]
public sealed class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _service;

    public AttendanceController(IAttendanceService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Mark(
        MarkAttendanceRequest request,
        CancellationToken ct)
    {
        var userId = User.FindFirst("uid")?.Value!;
        var id = await _service.MarkAsync(request, userId, ct);
        return Ok(new { SessionId = id });
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        UpdateAttendanceRequest request,
        CancellationToken ct)
    {
        await _service.UpdateAsync(request, ct);
        return Ok();
    }

    [HttpDelete("{sessionId}")]
    public async Task<IActionResult> Delete(string sessionId, CancellationToken ct)
    {
        await _service.DeleteSessionAsync(sessionId, ct);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] string academicYearId,
        [FromQuery] string classId,
        [FromQuery] string sectionId,
        [FromQuery] DateOnly date,
        CancellationToken ct)
    {
        return Ok(await _service.GetByDateAsync(academicYearId, classId, sectionId, date, ct));
    }
}
