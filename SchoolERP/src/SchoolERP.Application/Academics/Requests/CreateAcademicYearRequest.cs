namespace SchoolERP.Application.Academics.Requests;

public sealed class CreateAcademicYearRequest
{
    public string Name { get; set; } = default!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsCurrent { get; set; }
}
