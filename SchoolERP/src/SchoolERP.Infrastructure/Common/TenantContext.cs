using SchoolERP.Application.Common.Contracts;

namespace SchoolERP.Infrastructure.Common;

public class TenantContext : ITenantContext
{
    public string  TenantId { get; private set; }
    public string  BranchId { get; private set; }

    public void Set(string  tenantId, string  branchId)
    {
        TenantId = tenantId;
        BranchId = branchId;
    }
}
