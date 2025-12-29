using MediatR;
using WorkshopManager.Domain.Interfaces;

namespace WorkshopManager.Application.Features.Services.Commands.CreateService
{
    public class CreateServiceHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<CreateServiceCommand, Guid>
    {
        public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Domain.Entities.Service(
                request.Name,
                request.Price,
                request.EstimatedTimeInMinutes,
                request.Description
            );

            await unitOfWork.Services.AddAsync(service, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return service.Id;
        }
    }
}
