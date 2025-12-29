using MediatR;

namespace WorkshopManager.Application.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string SKU,
        string Name,
        decimal PurchasePrice,
        decimal SalePrice,
        int StockQuantity,
        int MinimumStock) : IRequest<Guid>; // Retorna o ID do produto criado
}
