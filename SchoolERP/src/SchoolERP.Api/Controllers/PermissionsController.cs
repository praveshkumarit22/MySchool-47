using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.Api.Common;
using SchoolERP.Application.Identity.Contracts;
using SchoolERP.Application.Identity.Interfaces;

namespace SchoolERP.Api.Controllers;

[Authorize]
public sealed class PermissionsController : BaseApiController
{
    private readonly IPermissionService _permissionService;

    public PermissionsController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var permissions = await _permissionService.GetAllAsync(ct);
        return Ok(permissions);
    }
}
