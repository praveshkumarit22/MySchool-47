using SchoolERP.Domain.Entities.Identity;

public sealed class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
        builder.Property(x => x.NormalizedName).HasMaxLength(150).IsRequired();
        builder.Property(x => x.Code).HasMaxLength(100).IsRequired();

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
