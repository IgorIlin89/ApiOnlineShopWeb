﻿using ApiUser.Application.Commands;
using ApiUser.Application.Handlers.Interfaces;
using ApiUser.Domain.Exceptions;
using ApiUser.Domain.Interfaces.Handlers;
using ApiUser.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace ApiUser.Controllers;

public class UserController(IGetUserListCommandHandler getUserListCommandHandler,
    IGetUserByEmailCommandHandler getUserByEmailCommandHandler,
    IGetUserByIdCommandHandler getUserByIdCommandHandler,
    IUpdateUserCommandHandler updateUserCommandHandler,
    IDeleteUserCommandHandler deleteUserCommandHandler,
    IAddUserCommandHandler addUserCommandHandler,
    IChangePasswordCommandHandler changePasswordCommandHandler) : ControllerBase
{
    [Route("user/list")]
    [HttpGet]
    public async Task<IActionResult> GetUserList(CancellationToken cancellationToken)
    {
        var userList = await getUserListCommandHandler.Handle(cancellationToken);

        return Ok(userList.MapToDtoList());
    }

    [Route("user/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
    {
        //if (id is null)
        //    {
        //        throw new NotFoundException($"The id may not be null when calling 'GetUserById'");
        //    }
        var command = new GetUserByIdCommand(id.ToString());
        var user = await getUserByIdCommandHandler.Handle(command, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException("No User found");
        }

        return Ok(user.MapToDto());
    }

    [Route("user/email/{email}")]
    [HttpGet]
    public async Task<ActionResult> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        var command = new GetUserByEmailCommand(email);
        var user = await getUserByEmailCommandHandler.Handle(command, cancellationToken);

        if (user is null)
        {
            throw new NotFoundException("No User found");
        }

        return Ok(user.MapToDto());
    }

    [Route("user")]
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] DtoUpdateUser updateUserDto,
        CancellationToken cancellationToken)
    {
        var commmand = new UpdateUserCommand(
            updateUserDto.UserId.ToString(), updateUserDto.EMail,
            updateUserDto.GivenName, updateUserDto.Surname, updateUserDto.Age,
            updateUserDto.Country, updateUserDto.City, updateUserDto.Street,
            updateUserDto.HouseNumber, updateUserDto.PostalCode, updateUserDto.Password);

        var user = await updateUserCommandHandler.Handle(commmand, cancellationToken);

        return Ok(user.MapToDto());
    }

    [Route("user/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id.ToString());
        await deleteUserCommandHandler.Handle(command, cancellationToken);
        return Ok();
    }

    [Route("user")]
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] DtoAddUser addUserDto,
        CancellationToken cancellationToken)
    {
        var command = new AddUserCommand(
            addUserDto.EMail,
            addUserDto.GivenName, addUserDto.Surname, addUserDto.Age,
            addUserDto.Country, addUserDto.City, addUserDto.Street,
            addUserDto.HouseNumber, addUserDto.PostalCode, addUserDto.Password);

        var user = await addUserCommandHandler.Handle(command, cancellationToken);

        return Ok(user.MapToDto());
    }

    [Route("user/changepassword")]
    [HttpPost]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto,
        CancellationToken cancellationToken)
    {
        var command = new ChangePasswordCommand(changePasswordDto.UserId.ToString(),
            changePasswordDto.Password);
        var user = await changePasswordCommandHandler.Handle(command, cancellationToken);
        return Ok(user.MapToDto());
    }
}
