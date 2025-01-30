using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Database.Interfaces;

public interface ICouponRepository
{
    Task<Coupon> AddCouponAsync(Coupon coupon, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task DeleteAsync(string code, CancellationToken cancellationToken);
    Task<Coupon> GetCouponByCodeAsync(string code, CancellationToken cancellationToken);
    Task<Coupon> GetCouponByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Coupon>> GetCouponListAsync(CancellationToken cancellationToken);
    Task<Coupon> UpdateAsync(Coupon coupon, CancellationToken cancellationToken);
}