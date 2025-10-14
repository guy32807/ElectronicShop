using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries
{
    public class GetBasketByUsernameQuery : IRequest<ShoppingCartResponse>
    {
        public GetBasketByUsernameQuery(string username)
        {
            Username = username;
        }

        public string Username { get; }
    }
}
