namespace SchoolERP.Domain.Common;

public abstract class TenantEntity : AuditableEntity
{
    public string  TenantId { get; set; }
    public string  BranchId { get; set; }
}
