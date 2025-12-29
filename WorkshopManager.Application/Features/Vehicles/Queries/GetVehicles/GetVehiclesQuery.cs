using MediatR;

namespace WorkshopManager.Application.Features.Vehicles.Queries.GetVehicles
{
    public record GetVehiclesQuery() : IRequest<IEnumerable<VehicleDto>>;
}
