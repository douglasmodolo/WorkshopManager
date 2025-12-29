using MediatR;

namespace WorkshopManager.Application.Features.Vehicles.Commands
{
    public record CreateVehicleCommand(
        string Plate,
        string Brand,
        string Model,
        int Year,
        string Color,
        Guid CustomerId,
        string? VIN = null) : IRequest<Guid>;
}
