using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IAddProductCommandHandler
{
    Task<Product> Handle(AddProductCommand command, CancellationToken cancellationToken);
}