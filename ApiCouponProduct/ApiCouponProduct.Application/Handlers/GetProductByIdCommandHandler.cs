using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers;

public class GetProductByIdCommandHandler(IProductRepository Repository) : IGetProductByIdCommandHandler
{
    public async Task<Product> Handle(GetProductByIdCommand command,
        CancellationToken cancellationToken)
    {
        return await Repository.GetProductById(command.Id, cancellationToken);
    }
}
