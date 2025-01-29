using ApiUser.Domain;

namespace ApiUser.Database.Interfaces;

public interface IUserRepository
{
    Task<User> AddUser(User user, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
    Task<User?> GetUserById(int id, CancellationToken cancellationToken);
    Task<User?> GetUserByEMail(string email, CancellationToken cancellationToken);
    Task<List<User>> GetUserList(CancellationToken cancellationToken);
    Task<User> Update(User user, CancellationToken cancellationToken);
    Task<User> ChangePassword(int id, string password, CancellationToken cancellationToken);
}