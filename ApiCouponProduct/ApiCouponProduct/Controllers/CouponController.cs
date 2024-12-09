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
    public async Task<IActionResult> GetCouponList()
    {
        var couponList = getCouponListCommandHandler.Handle();
        return Ok(couponList.MapToDtoList());
    }

    [Route("coupon/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetCouponById(int id)
    {
        var command = new GetCouponByIdCommand(id);
        var coupon = getCouponByIdCommandHandler.Handle(command);
        return Ok(coupon.MapToDto());
    }

    [Route("coupon/code/{code}")]
    [HttpGet]
    public async Task<IActionResult> GetCouponByCode(string code)
    {
        var command = new GetCouponByCodeCommand(code);
        var coupon = getCouponByCodeCommandHandler.Handle(command);
        return Ok(coupon.MapToDto());
    }

    [Route("coupon/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        var command = new DeleteCouponCommand(id);
        deleteCouponCommandHandler.Handle(command);
        return Ok();
    }

    [Route("coupon")]
    [HttpPut]
    public async Task<IActionResult> UpdateCoupon([FromBody] UpdateCouponDto updateCouponDto)
    {
        var command = new UpdateCouponCommand(updateCouponDto.CouponId, updateCouponDto.Code,
            updateCouponDto.AmountOfDiscount, updateCouponDto.TypeOfDiscount,
            updateCouponDto.MaxNumberOfUses, updateCouponDto.StartDate,
            updateCouponDto.EndDate);

        var coupon = updateCouponCommandHandler.Handle(command);
        return Ok(coupon.MapToDto());
    }

    [Route("coupon")]
    [HttpPost]
    public async Task<IActionResult> AddCoupon([FromBody] CouponDtoController couponDto)
    {
        var command = new AddCouponCommand(couponDto.Code, couponDto.AmountOfDiscount,
            couponDto.TypeOfDiscount.MapToDto(), couponDto.MaxNumberOfUses, couponDto.StartDate,
            couponDto.EndDate);

        var coupon = addCouponCommandHandler.Handle(command);

        return Ok(coupon.MapToDto());
    }

}
