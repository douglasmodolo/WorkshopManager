using WorkshopManager.Domain.Common;
using WorkshopManager.Domain.Exceptions;

namespace WorkshopManager.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string SKU { get; private set; }
        public string Name { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal SalePrice { get; private set; }
        public int StockQuantity { get; private set; }
        public int MinimumStock { get; private set; }

        protected Product() { }

        public Product(string sku, string name, decimal purchasePrice, decimal salePrice, int stockQuantity, int minimumStock)
        {
            SKU = sku;
            Name = name;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            StockQuantity = stockQuantity;
            MinimumStock = minimumStock;
        }

        public void RemoveFromStock(int quantity)
        {
            if (quantity <= 0) throw new DomainException("Quantity must be greater than zero.");
            if (StockQuantity < quantity) throw new DomainException($"Insufficient stock for {Name}.");

            StockQuantity -= quantity;
        }

        public void AddToStock(int quantity)
        {
            StockQuantity += quantity;
        }
    }
}
