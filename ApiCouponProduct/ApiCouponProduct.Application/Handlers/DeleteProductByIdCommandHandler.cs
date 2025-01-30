using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;

namespace ApiCouponProduct.Application.Handlers;

public class DeleteProductByIdCommandHandler(IUnitOfWork UnitOfWork, IProductRepository Repository)
    : IDeleteProductByIdCommandHandler
{
    public async Task Handle(DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        await Repository.Delete(command.Id, cancellationToken);
        await UnitOfWork.SaveChanges(cancellationToken);
    }
}
