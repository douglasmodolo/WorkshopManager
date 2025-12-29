namespace WorkshopManager.Application.Features.Vehicles.Queries.GetVehicles
{
    public record VehicleDto(
        Guid Id,
        string Plate,
        string Model,
        string Brand,
        int Year,
        string Color,
        string CustomerName
    );
}
