using SchoolERP.Domain.Entities.Identity;

public class MenuPermissionConfig : IEntityTypeConfiguration<MenuPermission>
{
    public void Configure(EntityTypeBuilder<MenuPermission> builder)
    {
        builder.ToTable("MenuPermissions");
        builder.HasKey(x => new { x.MenuId, x.PermissionId });
    }
}
