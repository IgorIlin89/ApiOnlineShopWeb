using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IGetProductByIdCommandHandler
{
    Task<Product> HandleAsync(GetProductByIdCommand command, CancellationToken cancellationToken);
}