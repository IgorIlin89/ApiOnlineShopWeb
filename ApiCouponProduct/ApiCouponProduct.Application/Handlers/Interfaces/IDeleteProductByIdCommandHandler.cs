using ApiCouponProduct.Application.Commands;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IDeleteProductByIdCommandHandler
{
    Task HandleAsync(DeleteProductCommand command, CancellationToken cancellationToken);
}