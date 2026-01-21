namespace SchoolERP.Application.Common.Contracts;

public interface ITenantContext
{
    string  TenantId { get; }
    string  BranchId { get; }
}
