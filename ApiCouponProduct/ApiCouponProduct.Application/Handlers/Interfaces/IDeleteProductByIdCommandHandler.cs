using ApiCouponProduct.Application.Commands;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IDeleteProductByIdCommandHandler
{
    Task Handle(DeleteProductCommand command, CancellationToken cancellationToken);
}