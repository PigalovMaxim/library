using System.Security.Cryptography;
using System.Text;
using CSharpFunctionalExtensions;
using Library.Domain.Shared;
using Entity = Library.Domain.Shared.Entity;

namespace Library.Domain.Modules;

public class User : Entity
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
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Hash { get; private set; }
    public int Rating { get; private set; }
    public Role Role { get; private set; }

    public static Result<User, Error> Create(
        string name,
        string email,
        string password)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            return Errors.General.ValueIsRequired("name, email or password");
        }

        if (name.Length < MIN_NAME_LENGTH || name.Length > MAX_NAME_LENGTH || email.Length > MAX_EMAIL_LENGTH ||
            email.Length < MIN_EMAIL_LENGTH)
        {
            return Errors.General.ValueIsInvalind("name or email");
        }
        
        var encodedPassword = new UTF8Encoding().GetBytes(email + password);
        var encoded = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
        var hash = BitConverter.ToString(encoded)
            .Replace("-", string.Empty)
            .ToLower();

        return new User(
            name,
            email,
            hash,
            0,
            Role.USER);
    }
}