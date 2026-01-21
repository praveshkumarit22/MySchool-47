using SchoolERP.Domain.Entities.Exams;

namespace SchoolERP.Infrastructure.Data.Configurations.Exams;

public sealed class QuestionConfig : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Questions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Text)
               .IsRequired()
               .HasMaxLength(2000);

        builder.Property(x => x.Type)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.DefaultMarks)
               .HasPrecision(6, 2);
    }
}
