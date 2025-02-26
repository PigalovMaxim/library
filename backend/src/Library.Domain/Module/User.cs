using CSharpFunctionalExtensions;

namespace Library.Domain.Module;

public class User
{
    public const int MAX_NAME_LENGTH = 100;
    public const int MIN_NAME_LENGTH = 2;
    public const int MAX_EMAIL_LENGTH = 200;
    public const int MIN_EMAIL_LENGTH = 2;
    
    //for ef core
    private User()
    {
    }
    
    private User(
        string name,
        string email,
        string hash,
        int rating,
        Role role
        )
    {
        Name = name;
        Email = email;
        Hash = hash;
        Rating = rating;
        Role = role;
    }
    
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Hash { get; private set; }
    public int Rating { get; private set; }
    public Role Role { get; private set; }

    public static Result<User> Create(
        string name,
        string email,
        string hash,
        int rating,
        Role role)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(hash))
        {
            return Result.Failure<User>("fields cannot be null or empty");
        }

        if (name.Length < MIN_NAME_LENGTH || name.Length > MAX_NAME_LENGTH || email.Length < MAX_EMAIL_LENGTH ||
            email.Length > MAX_EMAIL_LENGTH)
        {
            return Result.Failure<User>("email or name have incorrect characters count");
        }
        
        return Result.Success(new User(
            name,
            email,
            hash,
            rating,
            role));
    }
}