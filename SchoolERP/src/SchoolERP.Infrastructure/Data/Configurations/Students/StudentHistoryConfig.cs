using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolERP.Domain.Entities.Students;

namespace SchoolERP.Infrastructure.Data.Configurations.Students;

public sealed class StudentHistoryConfig : IEntityTypeConfiguration<StudentHistory>
{
    public void Configure(EntityTypeBuilder<StudentHistory> builder)
    {
        builder.ToTable("StudentHistories");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.RollNumber).HasMaxLength(50).IsRequired();
    }
}
