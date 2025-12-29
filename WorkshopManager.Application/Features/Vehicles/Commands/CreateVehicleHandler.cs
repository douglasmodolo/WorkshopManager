using MediatR;
using WorkshopManager.Domain.Entities;
using WorkshopManager.Domain.Exceptions;
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
                throw new NotFoundException($"O cliente com ID {request.CustomerId} não foi encontrado para esta oficina.");
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
