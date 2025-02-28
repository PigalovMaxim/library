using CSharpFunctionalExtensions;
using Library.Application.Users;
using Library.Domain.Modules;
using Library.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int, Error>> CreateUser(User user, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
        catch (Exception e)
        {
            return Errors.General.SomethingWentWrong();
        }
    }

    public async Task<Result<User, Error>> GetUserById(int id, CancellationToken cancellationToken = default)
    {
        try{
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (user is null)
                return Errors.General.NotFound(id);

            return user;
        }
        catch (Exception e)
        {
            return Errors.General.SomethingWentWrong();
        }
    }
    
    public async Task<Result<User, Error>> GetUserByEmail(string email, CancellationToken cancellationToken = default)
    {
        try{
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            if (user is null)
                return Errors.General.NotFound(email);

            return user;
        }
        catch (Exception e)
        {
            return Errors.General.SomethingWentWrong();
        }
    }
    
    public async Task<Result<List<User>, Error>> GetAllUsers(CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _dbContext.Users.ToListAsync(cancellationToken);

            return users;
        }
        catch (Exception e)
        {
            return Errors.General.SomethingWentWrong();
        }
    }
}