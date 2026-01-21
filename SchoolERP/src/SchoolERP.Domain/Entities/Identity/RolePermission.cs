namespace SchoolERP.Domain.Entities.Identity;

public class RolePermission
{
    public string RoleId { get; set; } = default!;
    public string PermissionId { get; set; } = default!;

    public Role Role { get; set; } = default!;
    public Permission Permission { get; set; } = default!;
}
