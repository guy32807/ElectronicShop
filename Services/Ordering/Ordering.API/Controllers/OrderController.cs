using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands;
using Ordering.Application.Queries;
using Ordering.Application.Responses;

namespace Ordering.API.Controllers
{
    public class OrderController(IMediator mediator, ILogger<OrderController> logger) : ApiController
    {
        [HttpGet("{username}", Name = "GetOrdersByUsername")]
        [ProducesResponseType(typeof(IEnumerable<OrderResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderResponse>> GetOrdersByUsername(string username)
        {
            var query = new GetOrderListQuery(username);
            var orders = await mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost(Name = "CheckoutOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            // Implementation for checkout order goes here
            var result = await mediator.Send(command);
            logger.LogInformation("CheckoutOrder endpoint called.");
            return Ok(result);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
