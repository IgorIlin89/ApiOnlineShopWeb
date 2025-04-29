using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;


namespace ApiCouponProduct.Application.Handlers;

public class DeleteCouponCommandHandler(IUnitOfWork UnitOfWork, ICouponRepository Repository)
    : IDeleteCouponCommandHandler
{
    public async Task HandleAsync(DeleteCouponCommand command,
        CancellationToken cancellationToken)
    {
        await Repository.DeleteAsync(command.Code, cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
