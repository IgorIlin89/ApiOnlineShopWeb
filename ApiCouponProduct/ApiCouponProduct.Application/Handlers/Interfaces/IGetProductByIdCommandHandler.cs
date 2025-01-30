using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IGetProductByIdCommandHandler
{
    Task<Product> Handle(GetProductByIdCommand command, CancellationToken cancellationToken);
}