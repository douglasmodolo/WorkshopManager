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

            await unitOfWork.Customers.AddAsync(customer, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return customer.Id;
        }
    }
}
