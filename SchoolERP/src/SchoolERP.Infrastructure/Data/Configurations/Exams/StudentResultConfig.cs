using SchoolERP.Domain.Entities.Exams;

namespace SchoolERP.Infrastructure.Data.Configurations.Exams;

public sealed class StudentResultConfig : IEntityTypeConfiguration<StudentResult>
{
    public void Configure(EntityTypeBuilder<StudentResult> builder)
    {
        builder.ToTable("StudentResults");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StudentId)
               .IsRequired();

        builder.Property(x => x.ExamId)
               .IsRequired();

        builder.Property(x => x.TotalMarks)
               .HasPrecision(7, 2);

        builder.Property(x => x.ObtainedMarks)
               .HasPrecision(7, 2);

        builder.Property(x => x.Percentage)
               .HasPrecision(5, 2);

        builder.Property(x => x.ResultStatus)
               .HasMaxLength(30)
               .IsRequired();

        builder.HasMany(x => x.Subjects)
               .WithOne(x => x.StudentResult)
               .HasForeignKey(x => x.StudentResultId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
