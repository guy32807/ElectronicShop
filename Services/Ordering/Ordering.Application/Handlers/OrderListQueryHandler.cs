using AutoMapper;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers
{
    public class OrderListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        : IRequestHandler<GetOrderListQuery, List<OrderResponse>>
    {
        public async Task<List<OrderResponse>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var orderList = await orderRepository.GetOrdersByUserNameAsync(request.Username);
            return mapper.Map<List<OrderResponse>>(orderList);
        }
    }
}
