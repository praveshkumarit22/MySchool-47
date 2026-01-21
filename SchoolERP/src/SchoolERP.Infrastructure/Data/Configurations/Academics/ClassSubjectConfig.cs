using SchoolERP.Domain.Entities.Academics;

namespace SchoolERP.Infrastructure.Data.Configurations.Academics;

public sealed class ClassSubjectConfig : IEntityTypeConfiguration<ClassSubject>
{
    public void Configure(EntityTypeBuilder<ClassSubject> builder)
    {
        builder.ToTable("ClassSubjects");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.SchoolClassId, x.SubjectId }).IsUnique();

        builder.HasOne(x => x.SchoolClass)
               .WithMany(x => x.Subjects)
               .HasForeignKey(x => x.SchoolClassId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Subject)
               .WithMany()
               .HasForeignKey(x => x.SubjectId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
