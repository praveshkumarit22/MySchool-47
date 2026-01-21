using SchoolERP.Application.Identity.Dtos;
using SchoolERP.Application.Identity.Requests.Auth;

namespace SchoolERP.Application.Identity.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}
