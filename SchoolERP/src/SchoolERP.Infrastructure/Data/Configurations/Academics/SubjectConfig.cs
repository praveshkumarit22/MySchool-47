using SchoolERP.Domain.Entities.Academics;

namespace SchoolERP.Infrastructure.Data.Configurations.Academics;

public sealed class SubjectConfig : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasIndex(x => new { x.TenantId, x.Name }).IsUnique();
    }
}
