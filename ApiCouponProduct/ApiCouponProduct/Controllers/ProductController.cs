using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ApiCouponProduct.Controllers;

//[Route("[controller]")]
public class ProductController(IGetProductListCommandHandler getProductListCommandHandler,
    IGetProductByIdCommandHandler getProductByIdCommandHandler,
    IDeleteProductByIdCommandHandler deleteProductByIdCommandHandler,
    IUpdateProductCommandHandler updateProductCommandHandler,
    IAddProductCommandHandler addProductCommandHandler) : ControllerBase
{
    [Route("product/list")]
    [HttpGet]
    public async Task<IActionResult> GetProductList(CancellationToken cancellationToken)
    {
        var productList = await getProductListCommandHandler.HandleAsync(cancellationToken);
        return Ok(productList.MapToDtoList());
    }

    [Route("product/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetProductById(int id,
        CancellationToken cancellationToken)
    {
        var command = new GetProductByIdCommand(id);
        var product = await getProductByIdCommandHandler.HandleAsync(command, cancellationToken);
        return Ok(product.MapToDto());
    }

    [Route("product/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id,
        CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);
        await deleteProductByIdCommandHandler.HandleAsync(command, cancellationToken);
        return Ok();
    }

    [Route("product")]
    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto,
        CancellationToken cancellationToken)
    {
        var command = new UpdateProductCommand(updateProductDto.ProductId,
            updateProductDto.Name,
            updateProductDto.Producer, updateProductDto.Category,
            updateProductDto.Picture, updateProductDto.Price);

        var product = await updateProductCommandHandler.HandleAsync(command, cancellationToken);

        return Ok(product.MapToDto());
    }

    [Route("product")]
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto productDto,
        CancellationToken cancellationToken)
    {

        var command = new AddProductCommand(productDto.Name, productDto.Producer,
            productDto.Category, productDto.Picture, productDto.Price);

        var product = await addProductCommandHandler.HandleAsync(command, cancellationToken);
        return Ok(product.MapToDto());
    }
}