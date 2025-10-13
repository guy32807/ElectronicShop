using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByIdHandler(IProductRepository productRepository)
        : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetProductByIdAsync(request.Id);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(product);
            return productResponse!;
        }
    }
}
