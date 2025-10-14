using Basket.Application.Commands;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers
{
    public class DeleteBasketByUsernameHandler(IBasketRepository basketRepository)
        : IRequestHandler<DeleteBasketByUsernameCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteBasketByUsernameCommand request, CancellationToken cancellationToken)
        {
            await basketRepository.DeleteBasket(request.Username);
            return Unit.Value;
        }
    }
}
