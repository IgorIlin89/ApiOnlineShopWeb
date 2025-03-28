﻿using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;

namespace ApiCouponProduct.Application.Handlers;

public class DeleteProductByIdCommandHandler(IUnitOfWork UnitOfWork, IProductRepository Repository)
    : IDeleteProductByIdCommandHandler
{
    public async Task HandleAsync(DeleteProductCommand command,
        CancellationToken cancellationToken)
    {
        await Repository.DeleteAsync(command.Id, cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
