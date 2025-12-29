using FluentValidation;

namespace WorkshopManager.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.DocumentId).NotEmpty().MinimumLength(11); // CPF/CNPJ
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
