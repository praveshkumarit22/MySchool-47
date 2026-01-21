public class IdCardTemplate : TenantEntity
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;

    public string FrontHtml { get; set; } = default!;
    public string BackHtml { get; set; } = default!;

    public bool IsDefault { get; set; }
}
