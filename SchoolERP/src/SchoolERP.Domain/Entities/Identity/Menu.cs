using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Identity;

public class Menu : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;

    public string Title { get; set; } = default!;
    public string Route { get; set; } = default!;
    public string Icon { get; set; } = default!;
    public string Group { get; set; } = default!;

    // ✅ expected by your code
    public int DisplayOrder { get; set; }

    // ✅ hierarchical menu
    public string? ParentId { get; set; }
    public Menu? Parent { get; set; }
    public ICollection<Menu> Children { get; set; } = new List<Menu>();

    // ✅ RBAC
    public ICollection<MenuPermission> Permissions { get; set; } = new List<MenuPermission>();

    public bool IsDeleted { get; set; }
}
