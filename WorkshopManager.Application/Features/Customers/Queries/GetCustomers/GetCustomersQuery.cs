using MediatR;

namespace WorkshopManager.Application.Features.Customers.Queries.GetCustomers
{
    public record GetCustomersQuery() : IRequest<IEnumerable<CustomerDto>>;
}
