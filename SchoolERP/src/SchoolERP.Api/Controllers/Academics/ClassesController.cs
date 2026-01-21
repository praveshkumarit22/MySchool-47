using Microsoft.AspNetCore.Mvc;
using SchoolERP.Application.Academics.Interfaces;
using SchoolERP.Application.Academics.Requests;

namespace SchoolERP.Api.Controllers.Academics;

[ApiController]
[Route("api/academics/classes")]
public sealed class ClassesController : ControllerBase
{
    private readonly IAcademicMasterService _service;

    public ClassesController(IAcademicMasterService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSchoolClassRequest request, CancellationToken ct)
    {
        var id = await _service.CreateClassAsync(request, ct);
        return Ok(new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateSchoolClassRequest request, CancellationToken ct)
    {
        await _service.UpdateClassAsync(id, request, ct);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _service.DeleteClassAsync(id, ct);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _service.GetClassesAsync(ct));
    }
}
