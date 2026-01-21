namespace SchoolERP.Application.Common.Models;

public class PagedResult<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string  TotalCount { get; set; }
    public IReadOnlyList<T> Items { get; set; } = [];
}
