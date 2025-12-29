using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkshopManager.Application.Features.Customers.Commands.CreateCustomer;
using WorkshopManager.Application.Features.Customers.Queries.GetCustomers;

namespace WorkshopManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetCustomersQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
