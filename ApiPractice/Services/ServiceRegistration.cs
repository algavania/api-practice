using ApiPractice.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Services;

public static class ServiceRegistration
{
    public static void AddApplicationServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        );
        services.AddScoped<AuthService>();
        services.AddScoped<UserService>();
    }
}