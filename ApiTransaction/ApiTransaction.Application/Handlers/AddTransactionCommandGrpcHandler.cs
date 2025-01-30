﻿using Transaction.Application.Commands;
using Transaction.Application.Interfaces;
using Transaction.Domain.Interfaces;

namespace Transaction.Application.Handlers;

public class AddTransactionCommandGrpcHandler(IUnitOfWork UnitOfWork,
    ITransactionRepository TransactionRepository) : IAddTransactionCommandGrpcHandler
{
    public async Task<Transaction.Domain.Transaction> Handle(AddTransactionCommand command,
        CancellationToken cancellationToken)
    {
        var transactionToAdd = Transaction.Domain.Transaction.Create(
            command.UserId,
            command.ProductInCartList,
            command.CouponsUsed
            );

        var result = await TransactionRepository.AddAsync(transactionToAdd, cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}
