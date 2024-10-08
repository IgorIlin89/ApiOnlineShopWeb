﻿using Transaction.Application.Commands;

namespace Transaction.Application.Interfaces;

public interface IAddTransactionCommandHandler
{
    Domain.Transaction Handle(AddTransactionCommand command);
}