using FluentValidation;

namespace WorkshopManager.Application.Features.Vehicles.Commands
{
    public class CreateVehicleValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleValidator()
        {
            RuleFor(v => v.Plate)
                .NotEmpty().WithMessage("A placa é obrigatória.")
                .Length(7, 8).WithMessage("A placa deve ter entre 7 e 8 caracteres.")
                .Matches(@"^[a-zA-Z]{3}-?[0-9][a-zA-Z0-9][0-9]{2}$")
                .WithMessage("O formato da placa é inválido.");

            RuleFor(v => v.Brand)
                .NotEmpty().WithMessage("A marca é obrigatória.")
                .MaximumLength(50).WithMessage("A marca deve ter no máximo 50 caracteres.");

            RuleFor(v => v.Model)
                .NotEmpty().WithMessage("O modelo é obrigatório.")
                .MaximumLength(50).WithMessage("O modelo deve ter no máximo 50 caracteres.");

            RuleFor(v => v.Year)
                .InclusiveBetween(1900, DateTime.Now.Year + 1)
                .WithMessage($"O ano deve estar entre 1900 e {DateTime.Now.Year + 1}.");

            RuleFor(v => v.Color)
                .NotEmpty().WithMessage("A cor é obrigatória.");

            RuleFor(v => v.CustomerId)
                .NotEmpty().WithMessage("O ID do cliente é obrigatório.");

            RuleFor(v => v.VIN)
                .MaximumLength(17).WithMessage("O chassi (VIN) deve ter no máximo 17 caracteres.")
                .When(v => !string.IsNullOrEmpty(v.VIN));
        }
    }
}
