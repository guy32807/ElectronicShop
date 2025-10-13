using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductsByTypeQuery : IRequest<IEnumerable<ProductResponse>>
    {
        public string Type { get; set; }
        public GetProductsByTypeQuery(string type)
        {
            Type = type;
        }
    }
}
