using ApiCouponProduct.Application.Commands;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IDeleteCouponCommandHandler
{
    Task Handle(DeleteCouponCommand command, CancellationToken cancellationToken);
}