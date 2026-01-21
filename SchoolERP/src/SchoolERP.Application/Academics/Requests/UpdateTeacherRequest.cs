namespace SchoolERP.Application.Academics.Requests;

public sealed class UpdateTeacherRequest
{
    public string FullName { get; set; } = default!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool IsActive { get; set; }
}
