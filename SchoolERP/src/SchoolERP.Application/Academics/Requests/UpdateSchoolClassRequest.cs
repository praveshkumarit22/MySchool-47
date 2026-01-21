namespace SchoolERP.Application.Academics.Requests;

public sealed class UpdateSchoolClassRequest
{
    public string Name { get; set; } = default!;
    public int SortOrder { get; set; }
}
