using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers;

public class UpdateCouponCommandHandler(IUnitOfWork UnitOfWork, ICouponRepository Repository)
    : IUpdateCouponCommandHandler
{
    public async Task<Coupon> Handle(UpdateCouponCommand command, CancellationToken cancellationToken)
    {
        var couponToUpdate = new Coupon
        {
            Id = command.Id,
            Code = command.Code,
            AmountOfDiscount = command.AmountOfDiscount,
            TypeOfDiscount = command.TypeOfDiscount,
            MaxNumberOfUses = command.MaxNumberOfUses,
            StartDate = command.StartDate,
            EndDate = command.EndDate
        };
        var coupon = await Repository.UpdateAsync(couponToUpdate, cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return coupon;
    }
}
