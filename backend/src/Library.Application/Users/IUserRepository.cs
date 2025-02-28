using CSharpFunctionalExtensions;
using Library.Domain.Modules;
using Library.Domain.Shared;

namespace Library.Application.Users;

public interface IUserRepository
{
    Task<Result<int, Error>> CreateUser(User user, CancellationToken cancellationToken = default);
    Task<Result<User, Error>> GetUserById(int id, CancellationToken cancellationToken = default);
    Task<Result<List<User>, Error>> GetAllUsers(CancellationToken cancellationToken = default);
    Task<Result<User, Error>> GetUserByEmail(string email, CancellationToken cancellationToken = default);
}