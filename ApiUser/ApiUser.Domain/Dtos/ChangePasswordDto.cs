﻿namespace ApiUser.Domain.Dtos;

public class ChangePasswordDto
{
    public int UserId { get; set; }
    public string Password { get; set; }
}
