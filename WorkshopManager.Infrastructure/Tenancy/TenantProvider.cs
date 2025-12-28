using Microsoft.AspNetCore.Http;
using WorkshopManager.Domain.Common;

namespace WorkshopManager.Infrastructure.Tenancy
{
    public class TenantProvider(IHttpContextAccessor httpContextAccessor) : ITenantProvider
    {
        public Guid GetTenantId()
        {
            var tenantClaim = httpContextAccessor.HttpContext?.User?.FindFirst("tenant_id")?.Value;

            if (Guid.TryParse(tenantClaim, out var tenantIdFromClaim))
                return tenantIdFromClaim;

            var tenantHeader = httpContextAccessor.HttpContext?.Request.Headers["X-Tenant-Id"].ToString();

            if (Guid.TryParse(tenantHeader, out var tenantIdFromHeader))
                return tenantIdFromHeader;

            throw new UnauthorizedAccessException("Tenant context is missing. Access denied.");
        }
    }
}
