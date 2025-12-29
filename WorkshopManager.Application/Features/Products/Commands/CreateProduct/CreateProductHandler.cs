using MediatR;
using WorkshopManager.Domain.Entities;
using WorkshopManager.Domain.Interfaces;

namespace WorkshopManager.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.SKU,
                request.Name,
                request.PurchasePrice,
                request.SalePrice,
                request.StockQuantity,
                request.MinimumStock
            );

            await unitOfWork.Products.AddAsync(product, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return product.Id;
        }
    }
}