using CSharpFunctionalExtensions;

namespace Library.Domain.Module;

public class Role
{
    public const int MAX_NAME_LENGTH = 50;
    public const int MIN_NAME_LENGTH = 2;
    
    private Role()
    {
    }

    private Role(string name)
    {
        Name = name;
    }
    
    public int Id { get; private set; }
    
    public string Name { get; private set; }

    public static Result<Role> Create(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return Result.Failure<Role>("role name cannot be null or empty.");
        }

        if (name.Length > MAX_NAME_LENGTH || name.Length < MIN_NAME_LENGTH)
        {
            return Result.Failure<Role>($"role name must be between {MIN_NAME_LENGTH} and {MAX_NAME_LENGTH} characters.");
        }

        return Result.Success(new Role(name));
    }
}