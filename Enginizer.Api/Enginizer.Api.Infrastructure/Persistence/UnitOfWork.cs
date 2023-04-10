using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Enginizer.Api.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EnginizerDbContext context;
        private readonly ILogger<UnitOfWork> logger;

        public UnitOfWork(EnginizerDbContext context, ILogger<UnitOfWork> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task CompleteAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                logger.LogError($"Error saving the context changes : {ex}. Inner exception details: {ex.InnerException}");
            }
            catch (Exception ex)
            {
                logger.LogError($"Error saving the context changes : {ex}. Inner exception details: {ex.InnerException}");
            }
        }
    }
}
