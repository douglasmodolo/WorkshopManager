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
            if (quantity <= 0)
                throw new BusinessException("A quantidade deve ser maior que zero.");

            if (StockQuantity < quantity)
                throw new BusinessException($"Estoque insuficiente para o produto: {Name}.");

            StockQuantity -= quantity;
        }

        public void AddToStock(int quantity)
        {
            if (quantity <= 0)
                throw new BusinessException("A quantidade a ser adicionada deve ser maior que zero.");

            StockQuantity += quantity;
        }
    }
}
