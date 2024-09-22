using Microsoft.AspNetCore.Mvc;
using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain;
using Transaction.Service.Dtos;
using Transaction.Service.Dtos.Mapping;

namespace Transaction.Controllers;

public class Transaction( // TODO Rename to TransactionController, convention naming controller at end
    IGetTransactionListCommandHandler getTransactionListCommandHandler,
    IAddTransactionCommandHandler addTransactionCommandHandler) : ControllerBase
{
    [Route("transaction/list/{id}")]
    [HttpGet]
    public async Task<ActionResult> GetTransactionList(int id)
    {
        //Coding style: _var only when its readonly,
        //with lower case starting in primary consteructor
        var command = new GetTransactionListCommand(id);
        var result = getTransactionListCommandHandler.Handle(command);
        return Ok();
        //TODO return Ok(result.MapToDtoList());
    }

    [Route("transaction")]
    [HttpPost]
    public async Task<ActionResult> BuyShoppingCartItems([FromBody] AddTransactionDto addTransactionDto)
    {
        List<ProductInCart> productsInCart = addTransactionDto.ProductsInCart.MapToProductInCartList();
        List<TransactionToCoupons> couponsUsed = addTransactionDto.Coupons.MapToTransactionToCouponsList();

        var command = new AddTransactionCommand(addTransactionDto.UserId, productsInCart, couponsUsed);
        var result = addTransactionCommandHandler.Handle(command);
        return Ok();
        //TODO return Ok(result.MapToDto());
    }
}
