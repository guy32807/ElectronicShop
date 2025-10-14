using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    public class BasketController(IMediator mediator) : ApiController
    {
        [HttpGet("{username}", Name = "GetBasketByUsername")]
        [ProducesResponseType(typeof(ShoppingCartResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShoppingCartResponse>> GetBasketByUsername(string username)
        {
            var query = new GetBasketByUsernameQuery(username);
            var basket = await mediator.Send(query);
            return Ok(basket);
        }

        [HttpPost(Name = "CreateBasket")]
        [ProducesResponseType(typeof(ShoppingCartResponse), StatusCodes.Status201Created)]
        public async Task<ActionResult<ShoppingCartResponse>> CreateBasket([FromBody] CreateShoppingCartCommand createShoppingCartCommand)
        {
            //var command = new CreateShoppingCartCommand(createShoppingCartCommand);
            var basket = await mediator.Send(createShoppingCartCommand);
            return CreatedAtRoute("GetBasketByUsername", new { username = basket.Username }, basket);
        }

        [HttpDelete("{username}", Name = "DeleteBasket")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteBasket(string username)
        {
            var command = new DeleteBasketByUsernameCommand(username);
            await mediator.Send(command);
            return NoContent();
        }
    }
}
