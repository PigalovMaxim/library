namespace Library.Domain.Shared;

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalind(string? name = null)
        {
            var label = name ?? "value";
            return Error.Validation("value is invalid", $"{label} is invalid");
        }
        
        public static Error NoDataForUpdate()
        {
            return Error.Validation("no data for update", "no data for update");
        }
        
        public static Error NotFound(int? id = null)
        {
            var forId = id != null ? $"for id {id}" : "";
            return Error.NotFound("record not found", $"record not found ${forId}");
        }
        
        public static Error NotFound(string? value = null)
        {
            var forId = value ?? $"for value {value}";
            return Error.NotFound("record not found", $"record not found ${forId}");
        }
        
        public static Error ValueIsRequired(string? name = null)
        {
            var label = name ?? "value";
            return Error.Validation("value is required", $"{label} is required");
        }
        
        public static Error SomethingWentWrong()
        {
            return Error.Failure("something went wrong", $"something went wrong");
        }
    }

    public static class Users
    {
        public static Error UserIsAlreadyExist()
        {
            return Error.Validation("user is already exist", "user is already exist");
        }
    }
}