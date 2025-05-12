using InventoryService.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateInventory([FromBody] UpdateInventoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result ? Ok() : BadRequest("Failed to update inventory.");
        }
    }
}