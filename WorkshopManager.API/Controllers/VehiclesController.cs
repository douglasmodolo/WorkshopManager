using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkshopManager.Application.Features.Vehicles.Commands;
using WorkshopManager.Application.Features.Vehicles.Queries.GetVehicles;

namespace WorkshopManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetVehiclesQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
