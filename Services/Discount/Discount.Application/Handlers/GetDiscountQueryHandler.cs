using Discount.Application.Queries;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Handlers
{
    public class GetDiscountQueryHandler(IDiscountRepository discountRepository)
        : IRequestHandler<GetDiscountQuery, CouponModel>
    {
        public async Task<CouponModel> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var coupon = await discountRepository.GetDiscountAsync(request.ProductName);
            if (coupon == null)
            {
                throw new Exception($"Discount with ProductName={request.ProductName} not found.");
            }
            return new CouponModel
            {
                Id = coupon.Id,
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = (int)coupon.Amount
            };
        }
    }
}
