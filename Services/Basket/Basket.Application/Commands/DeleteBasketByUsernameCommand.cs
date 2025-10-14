using MediatR;

namespace Basket.Application.Commands
{
    public class DeleteBasketByUsernameCommand : IRequest<Unit>
    {
        public string Username { get; set; }
        public DeleteBasketByUsernameCommand(string username)
        {
            Username = username;
        }
    }
}
