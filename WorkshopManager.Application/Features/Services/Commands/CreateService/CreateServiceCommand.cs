using MediatR;

namespace WorkshopManager.Application.Features.Services.Commands.CreateService
{
    public record CreateServiceCommand(
        string Name,
        string? Description,
        decimal Price,
        int EstimatedTimeInMinutes) : IRequest<Guid>; // Retorna o ID do serviço criado
}
