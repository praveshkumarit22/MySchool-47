using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Academics;

public class ClassSubject : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;

    public string SchoolClassId { get; set; } = default!;
    public string SubjectId { get; set; } = default!;

    public bool IsDeleted { get; set; }

    public SchoolClass SchoolClass { get; set; } = default!;
    public Subject Subject { get; set; } = default!;
}
