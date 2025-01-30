using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiCouponProduct.Controllers;

public class CouponController(IGetCouponListCommandHandler getCouponListCommandHandler,
    IGetCouponByIdCommandHandler getCouponByIdCommandHandler,
    IGetCouponByCodeCommandHandler getCouponByCodeCommandHandler,
    IDeleteCouponCommandHandler deleteCouponCommandHandler,
    IUpdateCouponCommandHandler updateCouponCommandHandler,
    IAddCouponCommandHandler addCouponCommandHandler) : ControllerBase
{
    [Route("coupon/list")]
    [HttpGet]
    public async Task<IActionResult> GetCouponList(
        CancellationToken cancellationToken)
    {
        var couponList = await getCouponListCommandHandler.HandleAsync(cancellationToken);
        return Ok(couponList.MapToDtoList());
    }

    [Route("coupon/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetCouponById(int id,
        CancellationToken cancellationToken)
    {
        var command = new GetCouponByIdCommand(id);
        var coupon = await getCouponByIdCommandHandler.HandleAsync(command, cancellationToken);
        return Ok(coupon.MapToDto());
    }

    [Route("coupon/code/{code}")]
    [HttpGet]
    public async Task<IActionResult> GetCouponByCode(string code,
        CancellationToken cancellationToken)
    {
        var command = new GetCouponByCodeCommand(code);
        var coupon = await getCouponByCodeCommandHandler.HandleAsync(command,
            cancellationToken);
        return Ok(coupon.MapToDto());
    }

    [Route("coupon/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteCoupon(int id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteCouponCommand(id);
        await deleteCouponCommandHandler.HandleAsync(command, cancellationToken);
        return Ok();
    }

    [Route("coupon")]
    [HttpPut]
    public async Task<IActionResult> UpdateCoupon([FromBody] UpdateCouponDto updateCouponDto,
        CancellationToken cancellationToken)
    {
        var command = new UpdateCouponCommand(updateCouponDto.CouponId, updateCouponDto.Code,
            updateCouponDto.AmountOfDiscount, updateCouponDto.TypeOfDiscount,
            updateCouponDto.MaxNumberOfUses, updateCouponDto.StartDate,
            updateCouponDto.EndDate);

        var coupon = await updateCouponCommandHandler.HandleAsync(command, cancellationToken);
        return Ok(coupon.MapToDto());
    }

    [Route("coupon")]
    [HttpPost]
    public async Task<IActionResult> AddCoupon([FromBody] CouponDtoController couponDto,
        CancellationToken cancellationToken)
    {
        var command = new AddCouponCommand(couponDto.Code, couponDto.AmountOfDiscount,
            couponDto.TypeOfDiscount.MapToDto(), couponDto.MaxNumberOfUses, couponDto.StartDate,
            couponDto.EndDate);

        var coupon = await addCouponCommandHandler.HandleAsync(command, cancellationToken);

        return Ok(coupon.MapToDto());
    }

}
