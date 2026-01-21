using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolERP.Domain.Entities.Students;

namespace SchoolERP.Infrastructure.Data.Configurations.Students;

public sealed class StudentStatusHistoryConfig : IEntityTypeConfiguration<StudentStatusHistory>
{
    public void Configure(EntityTypeBuilder<StudentStatusHistory> builder)
    {
        builder.ToTable("StudentStatusHistory");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.OldStatus).HasMaxLength(30);
        builder.Property(x => x.NewStatus).HasMaxLength(30);
        builder.Property(x => x.Reason).HasMaxLength(300);
    }
}
