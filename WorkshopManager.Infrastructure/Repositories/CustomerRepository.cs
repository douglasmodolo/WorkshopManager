using WorkshopManager.Domain.Entities;
using WorkshopManager.Domain.Interfaces;
using WorkshopManager.Infrastructure.Data;

namespace WorkshopManager.Infrastructure.Repositories
{
    public class CustomerRepository(ApplicationDbContext context)
        : GenericRepository<Customer>(context), ICustomerRepository
    {
    }
}
