namespace SchoolERP.Application.Academics.Requests;

public sealed class CreateSectionRequest
{
    public string Name { get; set; } = default!;
    public int Capacity { get; set; }
}
