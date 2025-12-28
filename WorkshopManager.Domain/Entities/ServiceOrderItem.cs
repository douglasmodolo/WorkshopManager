using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopManager.Domain.Exceptions;

namespace WorkshopManager.Domain.Entities
{
    public class ServiceOrderItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ServiceOrderId { get; private set; }
        public Guid? ProductId { get; private set; }
        public Guid? ServiceId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Total => Quantity * UnitPrice;

        protected ServiceOrderItem() { }

        public ServiceOrderItem(Guid serviceOrderId, Guid? productId, Guid? serviceId, int quantity, decimal unitPrice)
        {
            if (productId == null && serviceId == null)
                throw new DomainException("Item must be either a product or a service.");

            ServiceOrderId = serviceOrderId;
            ProductId = productId;
            ServiceId = serviceId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
