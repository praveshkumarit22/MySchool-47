using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Academics;

public class AcademicYear : TenantEntity, ISoftDelete
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;        // 2025-2026
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsCurrent { get; set; }

    public bool IsDeleted { get; set; }
}
