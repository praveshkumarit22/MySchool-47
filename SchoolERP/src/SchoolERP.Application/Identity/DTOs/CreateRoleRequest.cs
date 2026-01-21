namespace SchoolERP.Application.Identity.DTOs;

public class CreateRoleRequest
{
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Description { get; set; }

    public List<string > PermissionIds { get; set; } = new();
}
