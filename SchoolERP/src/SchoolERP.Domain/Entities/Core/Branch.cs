namespace SchoolERP.Domain.Entities.Core;

public class Branch : TenantEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Phone { get; set; }
}
