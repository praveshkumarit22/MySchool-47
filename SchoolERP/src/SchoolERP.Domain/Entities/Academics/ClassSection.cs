using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Academics;

public class ClassSection : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;

    public string SchoolClassId { get; set; } = default!;
    public string SectionId { get; set; } = default!;

    public bool IsDeleted { get; set; }

    public SchoolClass SchoolClass { get; set; } = default!;
    public Section Section { get; set; } = default!;
}
