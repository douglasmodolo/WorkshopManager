using FluentValidation;

namespace WorkshopManager.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.SKU).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithName("Nome");
            RuleFor(x => x.PurchasePrice).GreaterThanOrEqualTo(0).WithName("Preço de Compra");
            RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(0).WithName("Preço de Venda");
            RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0).WithName("Quantidade em Estoque");
            RuleFor(x => x.MinimumStock).GreaterThanOrEqualTo(0).WithName("Estoque Mínimo");
        }
    }
}
