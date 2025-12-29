using MediatR;

namespace WorkshopManager.Application.Features.Services.Queries.GetServices
{
    public record GetServicesQuery : IRequest<IEnumerable<GetServicesDto>>;
}
