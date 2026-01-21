using Microsoft.EntityFrameworkCore;
using SchoolERP.Application.Identity.Contracts;
using SchoolERP.Application.Identity.Dtos;
using SchoolERP.Application.Identity.DTOs;
using SchoolERP.Infrastructure.Data;

namespace SchoolERP.Infrastructure.Identity.Services;

public class PermissionService : IPermissionService
{
    private readonly SchoolDbContext _db;

    public PermissionService(SchoolDbContext db)
    {
        _db = db;
    }
    public async Task<List<PermissionDto>> GetAllAsync(CancellationToken ct)
    {
        return await _db.Permissions
            .Select(p => new PermissionDto(p.Id, p.Name, p.Key, p.Group))
            .ToListAsync(ct);
    }

    public async Task<List<PermissionDto>> GetAllAsync()
        => await _db.Permissions
            .Select(x => new PermissionDto(x.Id, x.Name, x.Key, x.Group))
            .ToListAsync();
}
