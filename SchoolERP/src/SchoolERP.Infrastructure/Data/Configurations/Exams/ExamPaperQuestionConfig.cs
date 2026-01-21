using SchoolERP.Domain.Entities.Exams;

namespace SchoolERP.Infrastructure.Data.Configurations.Exams;

public sealed class ExamPaperQuestionConfig : IEntityTypeConfiguration<ExamPaperQuestion>
{
    public void Configure(EntityTypeBuilder<ExamPaperQuestion> builder)
    {
        builder.ToTable("ExamPaperQuestions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ExamPaperSetId)
               .IsRequired();

        builder.Property(x => x.QuestionId)
               .IsRequired();

        builder.Property(x => x.QuestionNo)
               .IsRequired();

        // Prevent silent truncation
        builder.Property(x => x.Marks)
               .HasPrecision(6, 2);

        builder.HasOne(x => x.Question)
               .WithMany()
               .HasForeignKey(x => x.QuestionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
