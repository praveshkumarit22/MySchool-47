using SchoolERP.Application.Identity.Dtos;
using SchoolERP.Application.Identity.Requests.Auth;
using SchoolERP.Application.Identity.Requests.Users;

namespace SchoolERP.Application.Identity.Interfaces;

public interface IIdentityService
{
    Task<LoginResponse> LoginAsync(LoginRequest request, CancellationToken ct);

    Task<string > CreateUserAsync(CreateUserRequest request, CancellationToken ct);
}
