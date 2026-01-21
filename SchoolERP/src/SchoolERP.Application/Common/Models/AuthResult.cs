namespace SchoolERP.Application.Common.Models;

public record AuthResult(
    string  UserId,
    string FullName,
    string UserName,
    string Email,
    string Token,
    DateTime ExpiresAt
);
