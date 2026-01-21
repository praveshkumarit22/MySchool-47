namespace SchoolERP.Application.Common.Exceptions;

/// <summary>
/// Thrown when business validation fails.
/// Example: Duplicate admission number, invalid class assignment.
/// </summary>
public sealed class ValidationException : AppException
{
    public ValidationException(string message)
        : base(message, HttpStatus.BadRequest) // HTTP 400 semantics
    {
    }
}
