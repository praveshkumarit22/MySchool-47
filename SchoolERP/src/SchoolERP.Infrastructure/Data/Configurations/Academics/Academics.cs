using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolERP.Domain.Entities.Academics;

namespace SchoolERP.Infrastructure.Data.Configurations.Academics;

public sealed class AcademicYearConfig : IEntityTypeConfiguration<AcademicYear>
{
    public void Configure(EntityTypeBuilder<AcademicYear> builder)
    {
        builder.ToTable("AcademicYears");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasIndex(x => new { x.TenantId, x.Name }).IsUnique();

        builder.Property(x => x.IsCurrent).HasDefaultValue(false);
    }
}
