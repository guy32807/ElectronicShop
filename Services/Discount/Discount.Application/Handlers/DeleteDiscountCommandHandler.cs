using Discount.Application.Commands;
using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Handlers
{
    public class DeleteDiscountCommandHandler(IDiscountRepository discountRepository)
        : IRequestHandler<DeleteDiscountCommand, bool>
    {
        public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            return await discountRepository.DeleteDiscountAsync(request.ProductName);
        }
    }
}
