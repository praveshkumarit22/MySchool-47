using Microsoft.AspNetCore.Authorization;

namespace SchoolERP.Api.Auth;

public sealed class HasPermissionAttribute : AuthorizeAttribute
{
    private const string PREFIX = "PERMISSION:";

    public HasPermissionAttribute(string permission)
    {
        Policy = PREFIX + permission;
    }
}
