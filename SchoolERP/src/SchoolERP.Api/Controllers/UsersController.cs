using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolERP.Api.Auth;
using SchoolERP.Api.Common;
using SchoolERP.Application.Identity;
using SchoolERP.Application.Identity.Contracts;
using SchoolERP.Application.Identity.Interfaces;
using SchoolERP.Application.Identity.Requests.Users;

namespace SchoolERP.Api.Controllers;

[Authorize]
public sealed class UsersController : BaseApiController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    //[HttpPost]
    //public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken ct)
    //{
    //    var id = await _userService.CreateAsync(request, ct);
    //    return Ok(id);
    //}

    [HasPermission(Permissions.Users_Create)]
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken ct)
    {
        var id = await _userService.CreateAsync(request, ct);
        return Ok(id);
    }

}
