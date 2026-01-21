namespace SchoolERP.Application.Identity.Requests.Users;

public sealed class CreateUserRequest
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Password { get; set; } = default!;
    public bool IsActive { get; set; } = true;

    public List<string> RoleIds { get; set; } = new();
}
