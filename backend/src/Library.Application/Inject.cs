using Library.Application.Users.CreateUser;
using Library.Application.Users.GetUser;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateUserService>();
        services.AddScoped<GetUserService>();
        return services;
    }
}