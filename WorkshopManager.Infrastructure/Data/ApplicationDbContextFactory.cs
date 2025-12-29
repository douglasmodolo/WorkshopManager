using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WorkshopManager.Domain.Common;

namespace WorkshopManager.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WorkshopManager.API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseNpgsql(connectionString);

            return new ApplicationDbContext(builder.Options, new DesignTimeTenantProvider());
        }
    }

    /// <summary>
    /// Provider auxiliar apenas para uso em tempo de design (Migrations).
    /// </summary>
    public class DesignTimeTenantProvider : ITenantProvider
    {
        // Retorna um Guid vazio apenas para satisfazer a dependência do DbContext
        public Guid GetTenantId() => Guid.Empty;
    }
}
