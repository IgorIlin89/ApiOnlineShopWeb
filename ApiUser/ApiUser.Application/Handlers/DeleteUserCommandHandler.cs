﻿using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Database.Interfaces;

namespace ApiUser.Application.Handlers;

public class DeleteUserCommandHandler(IUnitOfWork UnitOfWork,
    IUserRepository Repository) : IDeleteUserCommandHandler
{
    public async Task HandleAsync(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        //if (id is null)
        //{
        //    throw new NotFoundException($"No id passed to delete the appropriate user");
        //}
        await Repository.DeleteAsync(Int32.Parse(command.UserId), cancellationToken);
        await UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
