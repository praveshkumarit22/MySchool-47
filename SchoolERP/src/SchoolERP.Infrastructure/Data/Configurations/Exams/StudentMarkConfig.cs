namespace SchoolERP.Infrastructure.Data.Configurations.Exams;

public sealed class StudentMarkConfig : IEntityTypeConfiguration<StudentMark>
{
    public void Configure(EntityTypeBuilder<StudentMark> builder)
    {
        builder.ToTable("StudentMarks");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StudentId)
               .IsRequired();

        builder.Property(x => x.ExamSubjectId)
               .IsRequired();

        // Prevent decimal truncation
        builder.Property(x => x.ObtainedMarks)
               .HasPrecision(6, 2);

        builder.Property(x => x.Grade)
               .HasMaxLength(20);

        builder.Property(x => x.Remarks)
               .HasMaxLength(250);

        // Force single FK mapping (fixes ExamSubjectId1 shadow FK)
        builder.HasOne(x => x.ExamSubject)
               .WithMany()
               .HasForeignKey(x => x.ExamSubjectId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
