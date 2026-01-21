using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Identity;

public class Role : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;

    public string? TenantId { get; set; }

    public string Name { get; set; } = default!;
    public string NormalizedName { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    // ✅ Many-to-many via UserRole
    public ICollection<UserRole> Users { get; set; } = new List<UserRole>();

    // ✅ Many-to-many via RolePermission
    public ICollection<RolePermission> Permissions { get; set; } = new List<RolePermission>();
}
