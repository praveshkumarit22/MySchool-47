namespace SchoolERP.Application.Academics.Requests;

public sealed class UpdateSubjectRequest
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
}
