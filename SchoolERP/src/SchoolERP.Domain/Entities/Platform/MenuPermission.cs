namespace SchoolERP.Domain.Entities.Identity;

public class MenuPermission
{
    public string MenuId { get; set; } = default!;
    public string PermissionId { get; set; } = default!;

    public Menu Menu { get; set; } = default!;
    public Permission Permission { get; set; } = default!;
}
