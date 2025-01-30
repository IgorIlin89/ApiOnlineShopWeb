using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;


namespace ApiCouponProduct.Application.Handlers;

public class AddCouponCommandHandler(IUnitOfWork UnitOfWork, ICouponRepository Repository)
    : IAddCouponCommandHandler
{
    public async Task<Coupon> Handle(AddCouponCommand command, CancellationToken cancellationToken)
    {
        var couponToAdd = new Coupon
        {
            Code = command.Code,
            AmountOfDiscount = command.AmountOfDiscount,
            TypeOfDiscount = command.TypeOfDiscount,
            MaxNumberOfUses = command.MaxNumberOfUses,
            StartDate = command.StartDate,
            EndDate = command.EndDate
        };

        var coupon = await Repository.AddCouponAsync(couponToAdd, cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return coupon;
    }
}