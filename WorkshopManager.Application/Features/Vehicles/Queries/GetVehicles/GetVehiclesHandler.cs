using MediatR;
using WorkshopManager.Domain.Interfaces;

namespace WorkshopManager.Application.Features.Vehicles.Queries.GetVehicles
{
    public class GetVehiclesHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetVehiclesQuery, IEnumerable<VehicleDto>>
    {
        public async Task<IEnumerable<VehicleDto>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {
            var vehicles = await unitOfWork.Vehicles.GetAllAsync(cancellationToken, v => v.Customer);

            return vehicles.Select(v => new VehicleDto(
                v.Id,
                v.Plate,
                v.Model,
                v.Brand,
                v.Year,
                v.Color,
                v.Customer?.Name ?? "Sem Proprietário"
            ));
        }
    }
}
