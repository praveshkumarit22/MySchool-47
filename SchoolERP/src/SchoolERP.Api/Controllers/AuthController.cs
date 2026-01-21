using Microsoft.AspNetCore.Mvc;
using SchoolERP.Api.Common;
using SchoolERP.Application.Identity.Interfaces;
using SchoolERP.Application.Identity.Requests.Auth;

namespace SchoolERP.Api.Controllers;

public sealed class AuthController : BaseApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken ct)
    {
        var result = await _authService.LoginAsync(request);
        return Ok(result);
    }
}
