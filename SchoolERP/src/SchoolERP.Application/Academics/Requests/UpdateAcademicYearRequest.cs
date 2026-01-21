namespace SchoolERP.Application.Academics.Requests;

public sealed class UpdateAcademicYearRequest
{
    public string Name { get; set; } = default!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsActive { get; set; }
}
