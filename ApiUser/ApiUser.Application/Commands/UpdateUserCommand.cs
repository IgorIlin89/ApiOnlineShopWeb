﻿namespace ApiUser.Application.Commands;

public record UpdateUserCommand(string Id, string EMail,
    string GivenName, string Surname, int Age,
    string Country, string City, string Street,
    int HouseNumber, int PostalCode)
{
}
