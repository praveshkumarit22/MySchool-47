using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.Application.Exams.Interfaces;
using SchoolERP.Application.Exams.Requests;

namespace SchoolERP.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/exams")]
public sealed class ExamsController : ControllerBase
{
    private readonly IExamService _service;

    public ExamsController(IExamService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateExamRequest request, CancellationToken ct)
        => Ok(await _service.CreateExamAsync(request, ct));

    [HttpPost("subject")]
    public async Task<IActionResult> AddSubject(AddExamSubjectRequest request, CancellationToken ct)
    {
        await _service.AddSubjectAsync(request, ct);
        return Ok();
    }

    [HttpPost("marks")]
    public async Task<IActionResult> SaveMarks(SaveMarksRequest request, CancellationToken ct)
    {
        await _service.SaveMarksAsync(request, ct);
        return Ok();
    }

    [HttpPost("{examId}/publish")]
    public async Task<IActionResult> Publish(string examId, CancellationToken ct)
    {
        await _service.PublishAsync(examId, ct);
        return Ok();
    }

    [HttpDelete("{examId}")]
    public async Task<IActionResult> Delete(string examId, CancellationToken ct)
    {
        await _service.DeleteAsync(examId, ct);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get(string academicYearId, CancellationToken ct)
        => Ok(await _service.GetAllAsync(academicYearId, ct));
}
