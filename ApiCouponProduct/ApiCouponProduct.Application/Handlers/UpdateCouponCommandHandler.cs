using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers;

public class UpdateCouponCommandHandler(IUnitOfWork UnitOfWork, ICouponRepository Repository) : IUpdateCouponCommandHandler
{
    public Coupon Handle(UpdateCouponCommand command)
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
        var coupon = Repository.Update(couponToUpdate);
        UnitOfWork.SaveChanges();
        return coupon;
    }
}
