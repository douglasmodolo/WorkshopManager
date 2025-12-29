namespace WorkshopManager.Application.Features.Products.Queries.GetProducts
{
    public record GetProductsDto(
        Guid Id,
        string SKU,
        string Name,
        decimal PurchasePrice,
        decimal SalePrice,
        int StockQuantity,
        int MinimumStock);
}
