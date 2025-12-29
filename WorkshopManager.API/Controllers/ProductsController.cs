using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkshopManager.Application.Features.Products.Commands.CreateProduct;
using WorkshopManager.Application.Features.Products.Queries.GetProducts;

namespace WorkshopManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetProductsQuery(), cancellationToken);
            return Ok(result);
        }
    }
}
