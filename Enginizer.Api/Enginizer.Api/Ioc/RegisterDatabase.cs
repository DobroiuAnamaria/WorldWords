using Enginizer.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Enginizer.Api.Ioc
{
    public static class RegisterDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EnginizerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly("Enginizer.Api")));
            var build = services.BuildServiceProvider();

            var scope = build.GetService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetRequiredService<EnginizerDbContext>().Database.Migrate();
            return services;
        }
    }
}
