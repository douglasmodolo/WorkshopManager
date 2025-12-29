using MediatR;
using WorkshopManager.Domain.Interfaces;

namespace WorkshopManager.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetProductsQuery, IEnumerable<GetProductsDto>>
    {
        public async Task<IEnumerable<GetProductsDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.Products.GetAllAsync(cancellationToken);

            return products.Select(p => new GetProductsDto(
                p.Id,
                p.SKU,
                p.Name,
                p.PurchasePrice,
                p.SalePrice,
                p.StockQuantity,
                p.MinimumStock));
        }
    }
}
