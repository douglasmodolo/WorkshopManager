using MediatR;
using WorkshopManager.Domain.Interfaces;

namespace WorkshopManager.Application.Features.Customers.Queries.GetCustomers
{
    public class GetCustomersHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>
    {
        public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await unitOfWork.Customers.GetAllAsync(cancellationToken);

            return customers.Select(c => new CustomerDto(
                c.Id,
                c.Name,
                c.Email,
                c.PhoneNumber));
        }
    }
}
