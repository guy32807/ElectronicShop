using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands
{
    public class CreateShoppingCartCommand : IRequest<ShoppingCartResponse>
    {
        public string Username { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
        public CreateShoppingCartCommand(string username, List<ShoppingCartItem> items)
        {
            Username = username;
            Items = items;
        }
    }
}
