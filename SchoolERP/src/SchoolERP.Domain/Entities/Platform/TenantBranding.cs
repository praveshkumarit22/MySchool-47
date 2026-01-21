public class TenantBranding : TenantEntity
{
    public string SchoolName { get; set; } = default!;
    public string LogoUrl { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string ThemeColor { get; set; } = "#000000";
}
