namespace WorkshopManager.Application.Features.Customers.Queries.GetCustomers
{
    public record CustomerDto(Guid Id, string Name, string Email, string PhoneNumber);
}
