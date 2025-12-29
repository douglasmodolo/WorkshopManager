using MediatR;
using WorkshopManager.Domain.Entities;
using WorkshopManager.Domain.Interfaces;

namespace WorkshopManager.Application.Features.Vehicles.Commands
{
    public class CreateVehicleHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateVehicleCommand, Guid>
    {
        public async Task<Guid> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var customer = await unitOfWork.Customers.GetByIdAsync(request.CustomerId, cancellationToken);

            if (customer == null)
            {
                throw new Exception("Cliente não encontrado ou não pertence a esta oficina.");
            }

            var vehicle = new Vehicle(
                request.Plate,
                request.Brand,
                request.Model,
                request.Year,
                request.Color,
                request.CustomerId,
                request.VIN);

            await unitOfWork.Vehicles.AddAsync(vehicle, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return vehicle.Id;
        }
    }
}
