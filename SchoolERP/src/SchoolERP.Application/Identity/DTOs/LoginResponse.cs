using SchoolERP.Application.Identity.DTOs;

namespace SchoolERP.Application.Identity.Dtos;

public sealed class LoginResponse
{
    public string AccessToken { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }

    public UserDto User { get; set; } = default!;
}
