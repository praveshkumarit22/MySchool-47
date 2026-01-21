using SchoolERP.Domain.Entities.Exams;

namespace SchoolERP.Infrastructure.Data.Configurations.Exams;

public sealed class StudentResultSubjectConfig : IEntityTypeConfiguration<StudentResultSubject>
{
    public void Configure(EntityTypeBuilder<StudentResultSubject> builder)
    {
        builder.ToTable("StudentResultSubjects");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StudentResultId)
               .IsRequired();

        builder.Property(x => x.SubjectId)
               .IsRequired();

        // IMPORTANT: prevent marks truncation
        builder.Property(x => x.MaxMarks)
               .HasPrecision(6, 2);

        builder.Property(x => x.ObtainedMarks)
               .HasPrecision(6, 2);

        builder.Property(x => x.Grade)
               .HasMaxLength(20);

        builder.HasOne(x => x.StudentResult)
               .WithMany(x => x.Subjects)
               .HasForeignKey(x => x.StudentResultId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
