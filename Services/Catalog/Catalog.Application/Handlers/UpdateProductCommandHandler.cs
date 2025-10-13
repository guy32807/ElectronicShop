using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<UpdateProductCommand, bool>
    {
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await productRepository.UpdateProductAsync(new Product
            {
                Id = request.Id,
                Name = request.Name,
                Summary = request.Summary,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Brands = request.Brands,
                Types = request.Types,
                Price = request.Price
            });
            return productEntity;
        }
    }
}
