using Library.Application.Users;
using Library.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}