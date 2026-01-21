using Microsoft.AspNetCore.Authorization;
using SchoolERP.Application.Identity.Authorization;

namespace SchoolERP.Infrastructure.Auth;

public sealed class PermissionRequirement
    : IAuthorizationRequirement, IPermissionRequirement
{
    public string Permission { get; }

    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}
