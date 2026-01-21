using Microsoft.AspNetCore.Mvc;
using SchoolERP.Application.Academics.Interfaces;
using SchoolERP.Application.Academics.Requests;

namespace SchoolERP.Api.Controllers.Academics;

[ApiController]
[Route("api/academics/subjects")]
public sealed class SubjectsController : ControllerBase
{
    private readonly IAcademicMasterService _service;

    public SubjectsController(IAcademicMasterService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSubjectRequest request, CancellationToken ct)
    {
        var id = await _service.CreateSubjectAsync(request, ct);
        return Ok(new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateSubjectRequest request, CancellationToken ct)
    {
        await _service.UpdateSubjectAsync(id, request, ct);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _service.DeleteSubjectAsync(id, ct);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _service.GetSubjectsAsync(ct));
    }
}
