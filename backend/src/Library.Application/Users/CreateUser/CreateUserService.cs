using CSharpFunctionalExtensions;
using Library.Domain.Modules;
using Library.Domain.Shared;

namespace Library.Application.Users.CreateUser;

public class CreateUserService
{
    private readonly IUserRepository _userRepository;
    
    public CreateUserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Result<int, Error>> Create(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var findUserResult = await _userRepository.GetUserByEmail(request.email, cancellationToken);
        if (findUserResult.IsFailure && findUserResult.Error.Type == ErrorType.Failure)
            return findUserResult.Error;
        if (findUserResult.IsSuccess)
            return Errors.Users.UserIsAlreadyExist();
        
        var userResult = User.Create(request.name, request.email, request.password);
        if (userResult.IsFailure)
            return userResult.Error;

        var createResult = await _userRepository.CreateUser(userResult.Value, cancellationToken);
        if (createResult.IsFailure)
            return createResult.Error;
        
        return createResult.Value;
    }
}