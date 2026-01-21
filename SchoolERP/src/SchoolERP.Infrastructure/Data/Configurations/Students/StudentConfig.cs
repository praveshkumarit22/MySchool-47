using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolERP.Domain.Entities.Students;

namespace SchoolERP.Infrastructure.Data.Configurations.Students;

public sealed class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AdmissionNo)
               .HasMaxLength(50)
               .IsRequired();

        builder.HasIndex(x => new { x.TenantId, x.AdmissionNo })
               .IsUnique();

        builder.Property(x => x.Status)
               .HasMaxLength(20)
               .IsRequired();

        builder.HasOne(x => x.Profile)
               .WithOne(x => x.Student)
               .HasForeignKey<StudentProfile>(x => x.StudentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Guardians)
               .WithOne(x => x.Student)
               .HasForeignKey(x => x.StudentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Documents)
               .WithOne(x => x.Student)
               .HasForeignKey(x => x.StudentId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Enrollments)
               .WithOne(x => x.Student)
               .HasForeignKey(x => x.StudentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.StatusHistory)
               .WithOne()
               .HasForeignKey(x => x.StudentId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
