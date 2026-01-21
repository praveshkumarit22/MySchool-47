using Microsoft.AspNetCore.Mvc;
using SchoolERP.Application.Academics.Interfaces;
using SchoolERP.Application.Academics.Requests;

namespace SchoolERP.Api.Controllers.Academics;

[ApiController]
[Route("api/academics/years")]
public sealed class AcademicYearsController : ControllerBase
{
    private readonly IAcademicMasterService _service;

    public AcademicYearsController(IAcademicMasterService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAcademicYearRequest request, CancellationToken ct)
    {
        var id = await _service.CreateAcademicYearAsync(request, ct);
        return Ok(new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, UpdateAcademicYearRequest request, CancellationToken ct)
    {
        await _service.UpdateAcademicYearAsync(id, request, ct);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _service.DeleteAcademicYearAsync(id, ct);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        return Ok(await _service.GetAcademicYearsAsync(ct));
    }
}
