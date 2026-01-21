namespace SchoolERP.Application.Academics.Requests;

public sealed class CreateSubjectRequest
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public bool IsElective { get; set; }
}
