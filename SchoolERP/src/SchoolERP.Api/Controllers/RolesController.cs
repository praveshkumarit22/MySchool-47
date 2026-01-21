using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.Api.Auth;
using SchoolERP.Api.Common;
using SchoolERP.Application.Identity;
using SchoolERP.Application.Identity.Contracts;
using SchoolERP.Application.Identity.Interfaces;

namespace SchoolERP.Api.Controllers;

[Authorize]
public sealed class RolesController : BaseApiController
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll(CancellationToken ct)
    //{
    //    var roles = await _roleService.GetAllAsync(ct);
    //    return Ok(roles);
    //}

    [HasPermission(Permissions.Roles_View)]
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var roles = await _roleService.GetAllAsync(ct);
        return Ok(roles);
    }


}
