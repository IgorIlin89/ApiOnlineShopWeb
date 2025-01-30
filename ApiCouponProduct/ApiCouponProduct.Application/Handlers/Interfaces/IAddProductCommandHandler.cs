using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IAddProductCommandHandler
{
    Task<Product> HandleAsync(AddProductCommand command, CancellationToken cancellationToken);
}