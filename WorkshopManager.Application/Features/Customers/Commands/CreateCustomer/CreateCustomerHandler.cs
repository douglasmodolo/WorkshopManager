using MediatR;
using WorkshopManager.Domain.Entities;
using WorkshopManager.Domain.Interfaces;

namespace WorkshopManager.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCustomerCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(
                request.Name,
                request.Email,
                request.PhoneNumber,
                request.DocumentId
            );

            // 1. Adiciona através do repositório exposto pelo UoW
            await unitOfWork.Customers.AddAsync(customer, cancellationToken);

            // 2. Commita a transação única
            await unitOfWork.CommitAsync(cancellationToken);

            return customer.Id;
        }
    }
}
