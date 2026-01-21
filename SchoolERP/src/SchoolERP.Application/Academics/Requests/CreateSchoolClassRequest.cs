namespace SchoolERP.Application.Academics.Requests;

public sealed class CreateSchoolClassRequest
{
    public string Name { get; set; } = default!;
    public int SortOrder { get; set; }
}
