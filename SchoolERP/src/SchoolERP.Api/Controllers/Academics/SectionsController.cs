using Microsoft.AspNetCore.Mvc;
using SchoolERP.Application.Academics.Interfaces;
using SchoolERP.Application.Academics.Requests;

namespace SchoolERP.Api.Controllers.Academics;

[ApiController]
[Route("api/academics/sections")]
public sealed class SectionsController : ControllerBase
{
    private readonly IAcademicMasterService _service;

    public SectionsController(IAcademicMasterService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateSectionRequest request, CancellationToken ct)
    {
        var id = await _service.CreateSectionAsync(request, ct);
        return Ok(new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateSectionRequest request, CancellationToken ct)
    {
        await _service.UpdateSectionAsync(id, request, ct);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _service.DeleteSectionAsync(id, ct);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _service.GetSectionsAsync(ct));
    }
}
