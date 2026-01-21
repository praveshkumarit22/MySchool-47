using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.Application.Students.Interfaces;
using SchoolERP.Application.Students.Requests;

namespace SchoolERP.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/promotions")]
public sealed class PromotionsController : ControllerBase
{
    private readonly IStudentPromotionService _service;

    public PromotionsController(IStudentPromotionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Promote(
        PromoteStudentRequest request,
        CancellationToken ct)
    {
        await _service.PromoteAsync(request, ct);
        return Ok();
    }

    [HttpGet("history/{studentId}")]
    public async Task<IActionResult> History(string studentId, CancellationToken ct)
    {
        return Ok(await _service.GetHistoryAsync(studentId, ct));
    }
}
