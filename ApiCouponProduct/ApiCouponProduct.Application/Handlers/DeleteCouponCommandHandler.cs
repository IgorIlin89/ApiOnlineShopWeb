using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;


namespace ApiCouponProduct.Application.Handlers;

public class DeleteCouponCommandHandler(IUnitOfWork UnitOfWork, ICouponRepository Repository)
    : IDeleteCouponCommandHandler
{
    public async Task Handle(DeleteCouponCommand command,
        CancellationToken cancellationToken)
    {
        await Repository.Delete(command.Id, cancellationToken);
        await UnitOfWork.SaveChanges(cancellationToken);
    }
}
