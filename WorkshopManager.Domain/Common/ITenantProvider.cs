namespace WorkshopManager.Domain.Common
{
    public interface ITenantProvider
    {
        Guid GetTenantId();
    }
}
