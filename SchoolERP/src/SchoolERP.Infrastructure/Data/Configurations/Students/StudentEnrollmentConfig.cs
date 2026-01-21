using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolERP.Domain.Entities.Students;

namespace SchoolERP.Infrastructure.Data.Configurations.Students;

public sealed class StudentEnrollmentConfig : IEntityTypeConfiguration<StudentEnrollment>
{
    public void Configure(EntityTypeBuilder<StudentEnrollment> builder)
    {
        builder.ToTable("StudentEnrollments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasIndex(x => new
        {
            x.TenantId,
            x.AcademicYearId,
            x.ClassId,
            x.SectionId,
            x.RollNumber
        }).IsUnique();

        builder.HasIndex(x => new
        {
            x.TenantId,
            x.StudentId,
            x.AcademicYearId
        }).IsUnique();
    }
}
