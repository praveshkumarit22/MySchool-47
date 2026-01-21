using SchoolERP.Application.Identity.Dtos;
using SchoolERP.Application.Identity.DTOs;

namespace SchoolERP.Application.Identity.Contracts;

public interface IPermissionService
{
    Task<List<PermissionDto>> GetAllAsync();
    Task<List<PermissionDto>> GetAllAsync(CancellationToken ct);
}
