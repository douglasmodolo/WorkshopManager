using MediatR;
using WorkshopManager.Domain.Interfaces;

namespace WorkshopManager.Application.Features.Services.Queries.GetServices
{
    public class GetServicesHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetServicesQuery, IEnumerable<GetServicesDto>>
    {
        public async Task<IEnumerable<GetServicesDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await unitOfWork.Services.GetAllAsync(cancellationToken);

            return services.Select(s => new GetServicesDto(
                s.Id,
                s.Name,
                s.Description,
                s.Price,
                s.EstimatedTimeInMinutes));
        }
    }
}
