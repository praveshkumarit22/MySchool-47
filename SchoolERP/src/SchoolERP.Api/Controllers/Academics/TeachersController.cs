using Microsoft.AspNetCore.Mvc;
using SchoolERP.Application.Academics.Interfaces;
using SchoolERP.Application.Academics.Requests;

namespace SchoolERP.Api.Controllers.Academics;

[ApiController]
[Route("api/academics/teachers")]
public sealed class TeachersController : ControllerBase
{
    private readonly IAcademicMasterService _service;

    public TeachersController(IAcademicMasterService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTeacherRequest request, CancellationToken ct)
    {
        var id = await _service.CreateTeacherAsync(request, ct);
        return Ok(new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateTeacherRequest request, CancellationToken ct)
    {
        await _service.UpdateTeacherAsync(id, request, ct);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _service.DeleteTeacherAsync(id, ct);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _service.GetTeachersAsync(ct));
    }
}
