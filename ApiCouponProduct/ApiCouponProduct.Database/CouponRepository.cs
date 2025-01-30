using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;
using ApiCouponProduct.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ApiCouponProduct.Database;

internal class CouponRepository : ICouponRepository
{
    private readonly ApiCouponProductContext _context;

    public CouponRepository(ApiCouponProductContext context)
    {
        _context = context;
    }

    public async Task<Coupon> AddCouponAsync(Coupon coupon, CancellationToken cancellationToken)
    {
        var existingCoupon = await _context.Coupon.FirstOrDefaultAsync(o => o.Code == coupon.Code,
            cancellationToken);

        if (existingCoupon is not null)
        {
            throw new CouponExistsException($"A coupon with the code '{coupon.Code}' " +
                $"allready exists and can not be added");
        }

        var response = await _context.Coupon.AddAsync(coupon, cancellationToken);

        return response.Entity;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var couponToDelete = await _context.Coupon.FirstOrDefaultAsync(o => o.Id == id,
            cancellationToken);

        if (couponToDelete is null)
        {
            throw new NotFoundException($"Coupon with the id '{id}' does not exist and could not be deleted");
        }

        _context.Coupon.Remove(couponToDelete);
    }

    public async Task DeleteAsync(string code, CancellationToken cancellationToken)
    {
        var couponToDelete = await _context.Coupon.FirstOrDefaultAsync(o => o.Code == code,
            cancellationToken);

        if (couponToDelete is null)
        {
            throw new NotFoundException($"Coupon with the code '{code}' does not exist and could not be deleted");
        }

        _context.Coupon.Remove(couponToDelete);
    }

    public async Task<Coupon> GetCouponByIdAsync(int id, CancellationToken cancellationToken)
    {
        var coupon = await _context.Coupon.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        if (coupon is null)
        {
            throw new NotFoundException($"Coupon with the id '{id}' does not exist");
        }

        return coupon;
    }

    public async Task<Coupon> GetCouponByCodeAsync(string code,
        CancellationToken cancellationToken)
    {
        var coupon = await _context.Coupon.FirstOrDefaultAsync(o => o.Code == code, cancellationToken);

        if (coupon is null)
        {
            throw new NotFoundException($"Coupon with the code '{code}' does not exist");
        }

        return coupon;
    }

    public async Task<List<Coupon>> GetCouponListAsync(CancellationToken cancellationToken)
    {
        return await _context.Coupon.ToListAsync(cancellationToken);
    }

    public async Task<Coupon> UpdateAsync(Coupon coupon, CancellationToken cancellationToken)
    {
        var couponToUpdate = await _context.Coupon.FirstOrDefaultAsync(o => o.Id == coupon.Id,
            cancellationToken);

        if (couponToUpdate is null)
        {
            throw new NotFoundException($"Coupon with the id '{coupon.Id}' does not exist and could not be updated");
        }

        couponToUpdate.Code = coupon.Code;
        couponToUpdate.AmountOfDiscount = coupon.AmountOfDiscount;
        couponToUpdate.TypeOfDiscount = coupon.TypeOfDiscount;
        couponToUpdate.MaxNumberOfUses = coupon.MaxNumberOfUses;
        couponToUpdate.StartDate = coupon.StartDate;
        couponToUpdate.EndDate = coupon.EndDate;

        return couponToUpdate;
    }
}
