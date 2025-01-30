using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IUpdateProductCommandHandler
{
    Task<Product> Handle(UpdateProductCommand command, CancellationToken cancellationToken);
}