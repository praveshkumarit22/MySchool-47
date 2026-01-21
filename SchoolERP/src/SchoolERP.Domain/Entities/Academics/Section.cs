using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Academics;

public class Section : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;     // A, B, C
    public int Capacity { get; set; }

    public bool IsDeleted { get; set; }
}
