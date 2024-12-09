using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;


namespace ApiCouponProduct.Application.Handlers;

public class AddCouponCommandHandler(IUnitOfWork UnitOfWork, ICouponRepository Repository) : IAddCouponCommandHandler
{
    public Coupon Handle(AddCouponCommand command)
    {
        //TODO
        var couponToAdd = new Coupon
        {
            Code = command.Code,
            AmountOfDiscount = command.AmountOfDiscount,
            TypeOfDiscount = command.TypeOfDiscount,
            MaxNumberOfUses = command.MaxNumberOfUses,
            StartDate = command.StartDate,
            EndDate = command.EndDate
        };

        var coupon = Repository.AddCoupon(couponToAdd);
        UnitOfWork.SaveChanges();
        return new Coupon();
        //return coupon;
    }
}