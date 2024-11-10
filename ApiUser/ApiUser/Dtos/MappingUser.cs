using ApiUser.Domain;

namespace ApiUser.Dtos;

public static class MappingUser
{
    public static DtoUpdateUser MapToDto(this User user) =>
         new DtoUpdateUser
         {
             UserId = user.Id,
             EMail = user.EMail,
             Password = user.Password,
             GivenName = user.GivenName,
             Surname = user.Surname,
             Age = user.Age,
             Country = user.Country,
             City = user.City,
             Street = user.Street,
             HouseNumber = user.HouseNumber,
             PostalCode = user.PostalCode,
         };


    public static User MapToUser(this DtoUpdateUser userDto) =>

        new User
        {
            Id = userDto.UserId,
            EMail = userDto.EMail,
            Password = userDto.Password,
            GivenName = userDto.GivenName,
            Surname = userDto.Surname,
            Age = userDto.Age,
            Country = userDto.Country,
            City = userDto.City,
            Street = userDto.Street,
            HouseNumber = userDto.HouseNumber,
            PostalCode = userDto.PostalCode,

        };

    public static User MapToUser(this DtoAddUser userDto) =>

        new User
        {
            EMail = userDto.EMail,
            Password = userDto.Password,
            GivenName = userDto.GivenName,
            Surname = userDto.Surname,
            Age = userDto.Age,
            Country = userDto.Country,
            City = userDto.City,
            Street = userDto.Street,
            HouseNumber = userDto.HouseNumber,
            PostalCode = userDto.PostalCode,
        };

    public static List<DtoUpdateUser> MapToDtoList(this List<User> userList) =>
        userList.Select(o => o.MapToDto()).ToList();
}
