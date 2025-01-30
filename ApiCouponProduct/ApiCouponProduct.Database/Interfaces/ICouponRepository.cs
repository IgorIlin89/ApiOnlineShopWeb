using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Database.Interfaces;

public interface ICouponRepository
{
    Task<Coupon> AddCoupon(Coupon coupon, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
    void Delete(string code);
    Task<Coupon> GetCouponByCode(string code, CancellationToken cancellationToken);
    Task<Coupon> GetCouponById(int id, CancellationToken cancellationToken);
    Task<List<Coupon>> GetCouponList(CancellationToken cancellationToken);
    Task<Coupon> Update(Coupon coupon, CancellationToken cancellationToken);
}