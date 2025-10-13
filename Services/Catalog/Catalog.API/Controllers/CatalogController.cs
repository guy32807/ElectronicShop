using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class CatalogController : ApiController
    {
        private readonly IMediator _mediator;
        public CatalogController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(Pagination<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pagination<ProductResponse>>> GetAllProducts([FromQuery] CatalogSpecParams catalogSpecParams)
        {
            var products = await _mediator.Send(new GetAllProductsQuery(catalogSpecParams));
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("GetProductsByName/{name}", Name = "GetProductsByName")]
        [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            var products = await _mediator.Send(new GetProductByNameQuery(name));
            return Ok(products);
        }

        [HttpGet("GetProductsByBrand/{brand}", Name = "GetProductsByBrand")]
        [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductsByBrand(string brand)
        {
            var products = await _mediator.Send(new GetProductByBrandQuery(brand));
            return Ok(products);
        }

        [HttpGet("GetProductsByType/{type}", Name = "GetProductsByType")]
        [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductsByType(string type)
        {
            var products = await _mediator.Send(new GetProductsByTypeQuery(type));
            return Ok(products);
        }

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return CreatedAtRoute("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return Ok(product);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _mediator.Send(new DeleteProductByIdCommand(id));
            return Ok(result);
        }
    }
}
