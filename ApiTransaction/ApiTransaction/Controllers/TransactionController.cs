using Microsoft.AspNetCore.Mvc;
using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Service.Dtos;
using Transaction.Service.Dtos.Mapping;

namespace Transaction.Service.Controllers;

public class TransactionController(
    IGetTransactionListCommandHandler getTransactionListCommandHandler,
    IAddTransactionCommandHandler addTransactionCommandHandler) : ControllerBase
{
    [Route("transaction/list/{id}")]
    [HttpGet]
    public async Task<ActionResult> GetTransactionList(int id,
        CancellationToken cancellationToken)
    {
        var command = new GetTransactionListCommand(id);
        var result = await getTransactionListCommandHandler.HandleAsync(command, cancellationToken);
        return Ok(result.MapToDtoList());
    }

    [Route("transaction")]
    [HttpPost]
    public async Task<ActionResult> BuyShoppingCartItems([FromBody] AddTransactionDto addTransactionDto,
        CancellationToken cancellationToken)
    {
        var productsInCart = addTransactionDto.AddProductsInCartDto.MapToDomain();
        var couponsUsed = addTransactionDto.AddCouponsDto.MapToCouponsList();

        var command = new AddTransactionCommand(addTransactionDto.UserId, productsInCart, couponsUsed);
        var result = await addTransactionCommandHandler.HandleAsync(command, cancellationToken);

        return Ok(result.MapToDto());
    }
}
