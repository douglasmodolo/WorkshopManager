using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkshopManager.Application.Features.Services.Commands.CreateService;
using WorkshopManager.Application.Features.Services.Queries.GetServices;

namespace WorkshopManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetServices(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetServicesQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
