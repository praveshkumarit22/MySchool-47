using SchoolERP.Application.Identity.Contracts;
using SchoolERP.Application.Identity.Dtos;
using SchoolERP.Application.Identity.DTOs;
using SchoolERP.Domain.Entities.Identity;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Identity.Services;

public class RoleService : IRoleService
{
    private readonly SchoolDbContext _db;

    public RoleService(SchoolDbContext db)
    {
        _db = db;
    }
    public async Task<List<RoleDto>> GetAllAsync(CancellationToken ct)
    {
        return await _db.Roles
            .Select(r => new RoleDto(r.Id, r.Name, r.Code, r.Description))
            .ToListAsync(ct);
    }

    public async Task<string > CreateAsync(CreateRoleRequest request)
    {
        var role = new Role
        {
            Id = DateTime.UtcNow.Ticks.ToString(),
            Name = request.Name,
            Code = request.Code,
            Description = request.Description
        };

        _db.Roles.Add(role);
        await _db.SaveChangesAsync();
        return role.Id;
    }

    public async Task AssignPermissionsAsync(string  roleId, List<string > permissionIds)
    {
        await _db.RolePermissions
            .Where(x => x.RoleId == roleId)
            .ExecuteDeleteAsync();

        foreach (var pid in permissionIds)
            _db.RolePermissions.Add(new RolePermission
            {
                RoleId = roleId,
                PermissionId = pid
            });

        await _db.SaveChangesAsync();
    }

    public async Task<List<RoleDto>> GetAllAsync()
        => await _db.Roles
            .Select(x => new RoleDto(x.Id, x.Name, x.Code, x.Description))
            .ToListAsync();
}
