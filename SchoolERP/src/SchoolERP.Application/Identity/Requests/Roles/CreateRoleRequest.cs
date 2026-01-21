namespace SchoolERP.Application.Identity.Requests.Roles;

public sealed class CreateRoleRequest
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
}
