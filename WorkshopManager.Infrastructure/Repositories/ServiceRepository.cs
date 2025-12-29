using WorkshopManager.Domain.Entities;
using WorkshopManager.Domain.Interfaces;
using WorkshopManager.Infrastructure.Data;

namespace WorkshopManager.Infrastructure.Repositories
{
    public class ServiceRepository(ApplicationDbContext context)
        : GenericRepository<Service>(context), IServiceRepository
    {
    }
}
