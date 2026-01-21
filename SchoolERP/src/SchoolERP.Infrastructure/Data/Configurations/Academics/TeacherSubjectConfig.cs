using SchoolERP.Domain.Entities.Academics;

namespace SchoolERP.Infrastructure.Data.Configurations.Academics;

public sealed class TeacherSubjectConfig : IEntityTypeConfiguration<TeacherSubject>
{
    public void Configure(EntityTypeBuilder<TeacherSubject> builder)
    {
        builder.ToTable("TeacherSubjects");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.TeacherId, x.ClassSubjectId }).IsUnique();

        builder.HasOne(x => x.Teacher)
               .WithMany(x => x.Subjects)
               .HasForeignKey(x => x.TeacherId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ClassSubject)
               .WithMany()
               .HasForeignKey(x => x.ClassSubjectId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
