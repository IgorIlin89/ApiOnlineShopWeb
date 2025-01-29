using Microsoft.AspNetCore.Mvc;
using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain;
using Transaction.Service.Dtos;
using Transaction.Service.Dtos.Mapping;

namespace Transaction.Service.Controllers;

public class TransactionController(
    IGetTransactionListCommandHandler getTransactionListCommandHandler,
    IAddTransactionCommandHandler addTransactionCommandHandler) : ControllerBase
{
    [Route("transaction/list/{id}")]
    [HttpGet]
    public async Task<ActionResult> GetTransactionList(int id)
    {
        var command = new GetTransactionListCommand(id);
        var result = getTransactionListCommandHandler.Handle(command);
        return Ok(result.MapToDtoList());
    }

    [Route("transaction")]
    [HttpPost]
    public async Task<ActionResult> BuyShoppingCartItems([FromBody] AddTransactionDto addTransactionDto,
        CancellationToken cancellationToken)
    {
        List<ProductInCart> productsInCart = addTransactionDto.AddProductsInCartDto.MapToProductInCartList();
        var couponsUsed = new List<TransactionToCoupons>();

        if (addTransactionDto.AddCouponsDto is not null)
        {
            couponsUsed = addTransactionDto.AddCouponsDto.MapToTransactionToCouponsList();
        }

        var command = new AddTransactionCommand(addTransactionDto.UserId, productsInCart, couponsUsed);
        var result = addTransactionCommandHandler.Handle(command, cancellationToken);

        return Ok(result.MapToDto());
    }
}
