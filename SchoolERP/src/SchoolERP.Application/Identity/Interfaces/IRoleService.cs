using SchoolERP.Application.Identity.Dtos;
using SchoolERP.Application.Identity.DTOs;

namespace SchoolERP.Application.Identity.Contracts;

public interface IRoleService
{
    Task<string > CreateAsync(CreateRoleRequest request);
    Task<List<RoleDto>> GetAllAsync();
    Task AssignPermissionsAsync(string  roleId, List<string > permissionIds);
    Task<List<RoleDto>> GetAllAsync(CancellationToken ct);

}
