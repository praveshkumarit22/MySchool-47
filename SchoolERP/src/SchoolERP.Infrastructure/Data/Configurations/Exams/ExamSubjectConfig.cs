using SchoolERP.Domain.Entities.Exams;

namespace SchoolERP.Infrastructure.Data.Configurations.Exams;

public sealed class ExamSubjectConfig : IEntityTypeConfiguration<ExamSubject>
{
    public void Configure(EntityTypeBuilder<ExamSubject> builder)
    {
        builder.ToTable("ExamSubjects");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ExamId)
               .IsRequired();

        builder.Property(x => x.SubjectId)
               .IsRequired();

        builder.Property(x => x.MaxMarks)
               .HasPrecision(6, 2);

        builder.Property(x => x.ExamDate)
               .IsRequired();

        builder.HasOne(x => x.Exam)
               .WithMany(x => x.Subjects)
               .HasForeignKey(x => x.ExamId)
               .IsRequired(false)   // soft-delete safe
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Marks)
               .WithOne(x => x.ExamSubject)
               .HasForeignKey(x => x.ExamSubjectId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
