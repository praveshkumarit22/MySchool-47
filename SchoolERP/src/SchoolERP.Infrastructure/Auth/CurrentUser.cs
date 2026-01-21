using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SchoolERP.Application.Common.Interfaces;

namespace SchoolERP.Infrastructure.Auth;

public sealed class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _http;

    public CurrentUser(IHttpContextAccessor http)
    {
        _http = http;
    }

    public string? UserId =>
        _http.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

    public string? Email =>
        _http.HttpContext?.User.FindFirstValue(ClaimTypes.Email);

    public IReadOnlyList<string> Permissions =>
        _http.HttpContext?.User.FindAll("permission")
            .Select(x => x.Value)
            .ToList() ?? new List<string>();
}
