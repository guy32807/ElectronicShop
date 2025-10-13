using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = ProductMapper.Mapper.Map<Product>(request);
            if (productEntity is null)
            {
                throw new ApplicationException("Issue with product mapping");
            }
            var newProduct = await productRepository.CreateProductAsync(productEntity);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
            if (productResponse is null)
            {
                throw new ApplicationException("Issue with product mapping");
            }
            return productResponse;
        }
    }
}
