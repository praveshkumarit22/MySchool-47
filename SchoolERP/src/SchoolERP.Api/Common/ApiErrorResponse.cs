namespace SchoolERP.Api.Common;

public sealed class ApiErrorResponse
{
    public string Message { get; set; } = default!;
    public string? Detail { get; set; }
    public string TraceId { get; set; } = default!;
}
