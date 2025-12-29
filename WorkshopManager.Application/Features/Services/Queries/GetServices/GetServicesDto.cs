namespace WorkshopManager.Application.Features.Services.Queries.GetServices
{
    public record GetServicesDto(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        int EstimatedTimeInMinutes
    );
}
