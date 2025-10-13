using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    public class BrandsController(IMediator mediator) : ApiController
    {
        [HttpGet]
        [Route("GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllBrands()
        {
            var query = new GetAllBrandsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
