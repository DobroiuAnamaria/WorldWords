using WebApplication1.Service;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Service.Ioc
{
    public static class RegisterDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly("WebApplication1")));
            var build = services.BuildServiceProvider();

            var scope = build.GetService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetRequiredService<DbContext>().Database.Migrate();
            return services;
        }
    }
}
