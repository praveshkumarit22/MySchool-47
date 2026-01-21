using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Academics;

public class Teacher : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<TeacherSubject> Subjects { get; set; } = new List<TeacherSubject>();
}
