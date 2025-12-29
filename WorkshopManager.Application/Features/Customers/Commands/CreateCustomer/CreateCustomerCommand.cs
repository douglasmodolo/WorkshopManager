using MediatR;

namespace WorkshopManager.Application.Features.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand(
        string Name,
        string Email,
        string PhoneNumber,
        string DocumentId) : IRequest<Guid>; // Retorna o ID do cliente criado
}
