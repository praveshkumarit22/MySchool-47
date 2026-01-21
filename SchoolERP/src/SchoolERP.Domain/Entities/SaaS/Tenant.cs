using SchoolERP.Domain.Entities.Core;

namespace SchoolERP.Domain.Entities.SaaS;

public class Tenant : AuditableEntity
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
