namespace SchoolERP.Application.Identity.Requests.Permissions;

public sealed class CreatePermissionRequest
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string Module { get; set; } = default!;
}
