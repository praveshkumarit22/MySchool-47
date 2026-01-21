namespace SchoolERP.Application.Common.Interfaces;

public interface ICurrentUser
{
    string? UserId { get; }
    string? Email { get; }
    IReadOnlyList<string> Permissions { get; }
}
