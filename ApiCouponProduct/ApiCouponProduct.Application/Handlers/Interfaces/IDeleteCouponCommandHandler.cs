using ApiCouponProduct.Application.Commands;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IDeleteCouponCommandHandler
{
    Task HandleAsync(DeleteCouponCommand command, CancellationToken cancellationToken);
}