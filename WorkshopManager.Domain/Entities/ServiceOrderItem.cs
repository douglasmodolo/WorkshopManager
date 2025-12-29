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
                throw new BusinessException("O item deve ser obrigatoriamente um produto ou um serviço.");

            if (quantity <= 0)
                throw new BusinessException("A quantidade deve ser maior que zero.");

            if (unitPrice < 0)
                throw new BusinessException("O preço unitário não pode ser negativo.");

            ServiceOrderId = serviceOrderId;
            ProductId = productId;
            ServiceId = serviceId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
