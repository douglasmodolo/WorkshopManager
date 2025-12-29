using WorkshopManager.Domain.Entities;
using WorkshopManager.Domain.Interfaces;
using WorkshopManager.Infrastructure.Data;

namespace WorkshopManager.Infrastructure.Repositories
{
    public class VehicleRepository(ApplicationDbContext context)
        : GenericRepository<Vehicle>(context), IVehicleRepository
    {
    }
}
