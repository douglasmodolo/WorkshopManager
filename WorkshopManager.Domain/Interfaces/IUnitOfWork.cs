namespace WorkshopManager.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IVehicleRepository Vehicles { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
