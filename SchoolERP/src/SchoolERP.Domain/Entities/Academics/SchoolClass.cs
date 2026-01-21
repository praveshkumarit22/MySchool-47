using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Academics;

public class SchoolClass : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;     // Class 1, Nursery
    public int SortOrder { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<ClassSection> Sections { get; set; } = new List<ClassSection>();
    public ICollection<ClassSubject> Subjects { get; set; } = new List<ClassSubject>();
}
