using Library.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Extensions;

public static class ResponseExtensions
{
    public static ActionResult ToErrorResponse(this Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Authorized => StatusCodes.Status401Unauthorized,
            ErrorType.Failure => StatusCodes.Status500InternalServerError,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
        
        return new ObjectResult(error)
        {
            StatusCode = statusCode
        };
    }
}