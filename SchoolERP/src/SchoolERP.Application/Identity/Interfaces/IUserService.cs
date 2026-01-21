using SchoolERP.Application.Identity.Requests.Users;

namespace SchoolERP.Application.Identity.Contracts;

public interface IUserService
{
    Task<string > CreateAsync(CreateUserRequest request);
    Task<List<UserDto>> GetAllAsync();
    Task<string> CreateAsync(CreateUserRequest request, CancellationToken ct);
    Task AssignRolesAsync(string  userId, List<string > roleIds); 
}
