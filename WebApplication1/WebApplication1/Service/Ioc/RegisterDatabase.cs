using WebApplication1.Service;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repository;

namespace WebApplication1.Service.Ioc
{
    public static class RegisterDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
              b => b.MigrationsAssembly("WebApplication1")));

            var build = services.BuildServiceProvider();
            var scope = build.GetService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
            return services;
        }
    }
}
