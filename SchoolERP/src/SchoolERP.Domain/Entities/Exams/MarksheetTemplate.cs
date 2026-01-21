using SchoolERP.Domain.Common;

namespace SchoolERP.Domain.Entities.Exams;

public class MarksheetTemplate : TenantEntity
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;

    public string HeaderHtml { get; set; } = default!;
    public string BodyHtml { get; set; } = default!;
    public string FooterHtml { get; set; } = default!;

    public bool IsDefault { get; set; }
}
