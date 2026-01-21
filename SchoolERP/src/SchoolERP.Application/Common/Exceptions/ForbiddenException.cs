namespace SchoolERP.Application.Common.Exceptions;

/// <summary>
/// Thrown when user is authenticated but not authorized.
/// Example: Accessing payroll without permission.
/// </summary>
public sealed class ForbiddenException : AppException
{
    public ForbiddenException(string message)
        : base(message, HttpStatus.Forbidden) // HTTP 403 semantics
    {
    }

    

}
