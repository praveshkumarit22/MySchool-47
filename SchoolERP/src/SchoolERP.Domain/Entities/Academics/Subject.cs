using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Academics;

public class Subject : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public bool IsElective { get; set; }

    public bool IsDeleted { get; set; }
}
