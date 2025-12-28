using WorkshopManager.Domain.Common;
using WorkshopManager.Domain.Enums;
using WorkshopManager.Domain.Exceptions;

namespace WorkshopManager.Domain.Entities
{
    public class ServiceOrder : BaseEntity
    {
        public int Number { get; private set; }
        public Guid VehicleId { get; private set; }
        public ServiceOrderStatus Status { get; private set; }
        public string Notes { get; private set; }
        public decimal Discount { get; private set; }
        public DateTime EntryDate { get; private set; }
        public DateTime? ExitDate { get; private set; }

        private readonly List<ServiceOrderItem> _items = new();
        public virtual IReadOnlyCollection<ServiceOrderItem> Items => _items.AsReadOnly();

        public decimal TotalAmount => _items.Sum(x => x.Total) - Discount;

        protected ServiceOrder() { }

        public ServiceOrder(int number, Guid vehicleId, string notes, Guid tenantId)
        {
            Number = number;
            VehicleId = vehicleId;
            Notes = notes;
            TenantId = tenantId;
            Status = ServiceOrderStatus.Draft;
            EntryDate = DateTime.UtcNow;
        }

        public void AddItem(Guid? productId, Guid? serviceId, int quantity, decimal unitPrice)
        {
            if (Status != ServiceOrderStatus.Draft && Status != ServiceOrderStatus.PendingApproval)
                throw new DomainException("Cannot add items to an order in this status.");

            var item = new ServiceOrderItem(Id, productId, serviceId, quantity, unitPrice);
            _items.Add(item);
        }

        public void Complete()
        {
            if (Status != ServiceOrderStatus.InProgress)
                throw new DomainException("Order must be In Progress to be completed.");

            Status = ServiceOrderStatus.Completed;
            ExitDate = DateTime.UtcNow;
        }
    }
}
