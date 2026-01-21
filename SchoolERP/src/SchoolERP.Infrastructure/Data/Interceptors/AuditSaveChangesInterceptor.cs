using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SchoolERP.Domain.Entities.System;
using System.Text.Json;

namespace SchoolERP.Infrastructure.Data.Interceptors;

public sealed class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not DbContext db)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        var auditLogs = new List<AuditLog>();

        foreach (var entry in db.ChangeTracker.Entries())
        {
            if (entry.Entity is AuditLog) continue;
            if (entry.State == EntityState.Unchanged || entry.State == EntityState.Detached) continue;

            auditLogs.Add(new AuditLog
            {
                Id = Guid.NewGuid().ToString(),
                Action = entry.State.ToString(),
                EntityName = entry.Entity.GetType().Name,
                EntityId = entry.Properties.FirstOrDefault(p => p.Metadata.Name == "Id")?.CurrentValue?.ToString() ?? "",
                OldValues = entry.State == EntityState.Added ? null : JsonSerializer.Serialize(entry.OriginalValues.ToObject()),
                NewValues = JsonSerializer.Serialize(entry.CurrentValues.ToObject())
            });
        }

        if (auditLogs.Count > 0)
            db.Set<AuditLog>().AddRange(auditLogs);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
