using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.System;

public class AuditLog : TenantEntity
{
    public string Id { get; set; } = default!;
    public string? UserId { get; set; }

    public string Action { get; set; } = default!;     // Insert / Update / Delete
    public string EntityName { get; set; } = default!;
    public string EntityId { get; set; } = default!;

    public string? OldValues { get; set; }
    public string? NewValues { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
