using AutoMapper;
using Discount.Application.Commands;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Grpc.Protos;
using MediatR;

namespace Discount.Application.Handlers
{
    public class UpdateDiscountCommandHandler(IDiscountRepository discountRepository, IMapper mapper)
        : IRequestHandler<UpdateDiscountCommand, CouponModel>
    {
        public async Task<CouponModel> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = mapper.Map<Coupon>(request);
            await discountRepository.UpdateDiscountAsync(coupon);
            var couponModel = mapper.Map<CouponModel>(coupon);
            return couponModel;
        }
    }
}
