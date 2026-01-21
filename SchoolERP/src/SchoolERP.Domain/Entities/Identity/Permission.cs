namespace SchoolERP.Domain.Entities.Identity;

public class Permission : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;

    // SaaS / Tenant
    public string? TenantId { get; set; }

    // Core
    public string Name { get; set; } = default!;
    public string Key { get; set; } = default!;        // ex: Students.Create
    public string Group { get; set; } = default!;      // ex: Students, Users, Fees

    // Soft delete
    public bool IsDeleted { get; set; }

    // Navigation
    public ICollection<RolePermission> Roles { get; set; } = new List<RolePermission>();
}
