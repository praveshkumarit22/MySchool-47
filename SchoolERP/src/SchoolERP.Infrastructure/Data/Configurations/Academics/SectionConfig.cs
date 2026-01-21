using SchoolERP.Domain.Entities.Academics;

namespace SchoolERP.Infrastructure.Data.Configurations.Academics;

public sealed class SectionConfig : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("Sections");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(10)
               .IsRequired();

        builder.HasIndex(x => new { x.TenantId, x.Name });
    }
}
