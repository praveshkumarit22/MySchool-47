using SchoolERP.Domain.Entities.Identity;

namespace SchoolERP.Application.Identity.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUserNameOrEmailAsync(string userNameOrEmail);
    Task<User?> GetWithRolesAndPermissionsAsync(string userId);
}
