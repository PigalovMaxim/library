using CSharpFunctionalExtensions;
using Library.Domain.Modules;
using Library.Domain.Shared;

namespace Library.Application.Users.GetUser;

public class GetUserService
{
    private readonly IUserRepository _userRepository;
    
    public GetUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Result<User, Error>> Get(int id, CancellationToken cancellationToken = default)
    {
        var findUserResult = await _userRepository.GetUserById(id, cancellationToken);
        if (findUserResult.IsFailure)
            return findUserResult.Error;

        return findUserResult.Value;
    }
    
    public async Task<Result<User, Error>> Get(string email, CancellationToken cancellationToken = default)
    {
        var findUserResult = await _userRepository.GetUserByEmail(email, cancellationToken);
        if (findUserResult.IsFailure)
            return findUserResult.Error;

        return findUserResult.Value;
    }
    
    public async Task<Result<List<User>, Error>> GetAll(CancellationToken cancellationToken = default)
    {
        var findUserResult = await _userRepository.GetAllUsers(cancellationToken);
        if (findUserResult.IsFailure)
            return findUserResult.Error;

        return findUserResult.Value;
    } 
}