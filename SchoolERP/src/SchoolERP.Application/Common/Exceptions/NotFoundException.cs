namespace SchoolERP.Application.Common.Exceptions;

/// <summary>
/// Thrown when a requested resource does not exist.
/// Example: Student not found, User not found.
/// </summary>
public sealed class NotFoundException : AppException
{
    public NotFoundException(string message)
        : base(message, HttpStatus.NotFound) // HTTP 404 semantics, but without ASP.NET dependency
    {
    }
}
