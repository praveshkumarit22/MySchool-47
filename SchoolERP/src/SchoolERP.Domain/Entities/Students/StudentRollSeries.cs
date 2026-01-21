using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Students;

public class StudentRollSeries : TenantEntity
{
    public string Id { get; set; } = default!;
    public string AcademicYearId { get; set; } = default!;
    public string ClassId { get; set; } = default!;
    public string SectionId { get; set; } = default!;

    public int LastRollNumber { get; set; }
    public int CurrentRoll { get; set; }

}
