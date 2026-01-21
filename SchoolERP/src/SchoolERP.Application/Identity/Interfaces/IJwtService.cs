using SchoolERP.Domain.Entities.Identity;
namespace SchoolERP.Application.Identity.Interfaces;

public interface IJwtService
{
    string GenerateAccessToken(User user, List<string> roles, List<string> permissions);
    string GenerateRefreshToken();
}
