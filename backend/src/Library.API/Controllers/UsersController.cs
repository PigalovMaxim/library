using Library.API.Extensions;
using Library.Application.Users.CreateUser;
using Library.Application.Users.GetUser;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost()]
    public async Task<IActionResult> Create(
        [FromServices] CreateUserService createUserService,
        [FromBody] CreateUserRequest createUserRequest,
        CancellationToken cancellationToken = default)
    {
        var userResult = await createUserService.Create(createUserRequest, cancellationToken);
        if (userResult.IsFailure)
            return userResult.Error.ToErrorResponse();
        
        return Ok(userResult.Value);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(
        [FromRoute] int id,
        [FromServices] GetUserService getUserService,
        CancellationToken cancellationToken = default)
    {
        var userResult = await getUserService.Get(id, cancellationToken);
        if (userResult.IsFailure)
            return userResult.Error.ToErrorResponse();
        
        return Ok(userResult.Value);
    }
    
    [HttpGet("{email}")]
    public async Task<IActionResult> Get(
        [FromRoute] string email,
        [FromServices] GetUserService getUserService,
        CancellationToken cancellationToken = default)
    {
        var userResult = await getUserService.Get(email, cancellationToken);
        if (userResult.IsFailure)
            return userResult.Error.ToErrorResponse();
        
        return Ok(userResult.Value);
    }
    
    [HttpGet()]
    public async Task<IActionResult> Get(
        [FromServices] GetUserService getUserService,
        CancellationToken cancellationToken = default)
    {
        var usersResult = await getUserService.GetAll(cancellationToken);
        if (usersResult.IsFailure)
            return usersResult.Error.ToErrorResponse();
        
        return Ok(usersResult.Value);
    }
}