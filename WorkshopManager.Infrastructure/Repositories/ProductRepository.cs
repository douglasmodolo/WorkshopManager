using WorkshopManager.Domain.Entities;
using WorkshopManager.Domain.Interfaces;
using WorkshopManager.Infrastructure.Data;

namespace WorkshopManager.Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext context)
        : GenericRepository<Product>(context), IProductRepository
    {
    }
}
