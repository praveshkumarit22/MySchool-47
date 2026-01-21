namespace SchoolERP.Application.Common.Exceptions;

/// <summary>
/// Base exception type for all business and application errors.
/// This keeps the Application layer independent of HTTP / ASP.NET.
/// API layer will translate this into proper HTTP responses.
/// </summary>
public abstract class AppException : Exception
{
    /// <summary>
    /// Numeric status code (e.g. 400, 404, 403, 500).
    /// We keep this as int to avoid ASP.NET dependency.
    /// </summary>
    public int StatusCode { get; }

    protected AppException(string message, int statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
