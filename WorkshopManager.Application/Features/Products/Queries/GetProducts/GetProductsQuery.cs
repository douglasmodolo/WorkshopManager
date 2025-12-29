using MediatR;

namespace WorkshopManager.Application.Features.Products.Queries.GetProducts
{
    public record GetProductsQuery : IRequest<IEnumerable<GetProductsDto>>;
}
