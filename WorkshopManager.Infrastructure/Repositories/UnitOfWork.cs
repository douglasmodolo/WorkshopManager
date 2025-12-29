using WorkshopManager.Domain.Interfaces;
using WorkshopManager.Infrastructure.Data;

namespace WorkshopManager.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ICustomerRepository? _customers;

        public UnitOfWork(ApplicationDbContext context) => _context = context;

        public ICustomerRepository Customers => _customers ??= new CustomerRepository(_context);

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}
