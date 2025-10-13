using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductsByTypeHandler(IProductRepository productRepository)
        : IRequestHandler<GetProductsByTypeQuery, IEnumerable<ProductResponse>>
    {
        public async Task<IEnumerable<ProductResponse>> Handle(GetProductsByTypeQuery request, CancellationToken cancellationToken)
        {
            var productList = await productRepository.GetProductsByTypeAsync(request.Type);
            var productResponseList = ProductMapper.Mapper.Map<IList<ProductResponse>>(productList);
            return productResponseList!;
        }
    }
}
