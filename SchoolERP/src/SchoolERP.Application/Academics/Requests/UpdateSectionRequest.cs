namespace SchoolERP.Application.Academics.Requests;

public sealed class UpdateSectionRequest
{
    public string Name { get; set; } = default!;
    public int SortOrder { get; set; }
}
