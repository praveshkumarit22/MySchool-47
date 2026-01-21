using SchoolERP.Domain.Entities.Academics;

namespace SchoolERP.Infrastructure.Data.Configurations.Academics;

public sealed class SchoolClassConfig : IEntityTypeConfiguration<SchoolClass>
{
    public void Configure(EntityTypeBuilder<SchoolClass> builder)
    {
        builder.ToTable("SchoolClasses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(50)
               .IsRequired();

        builder.HasIndex(x => new { x.TenantId, x.Name }).IsUnique();

        builder.HasMany(x => x.Sections)
               .WithOne(x => x.SchoolClass)
               .HasForeignKey(x => x.SchoolClassId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Subjects)
               .WithOne(x => x.SchoolClass)
               .HasForeignKey(x => x.SchoolClassId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
