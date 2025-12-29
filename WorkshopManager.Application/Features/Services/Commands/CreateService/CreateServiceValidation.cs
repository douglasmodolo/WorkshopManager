using FluentValidation;

namespace WorkshopManager.Application.Features.Services.Commands.CreateService
{
    public class CreateServiceValidation : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100).WithName("Nome");
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithName("Preço");
            RuleFor(x => x.EstimatedTimeInMinutes).GreaterThanOrEqualTo(0).WithName("Tempo Estimado em Minutos");
            RuleFor(x => x.Description).MaximumLength(500).WithName("Descrição");
        }
    }
}
