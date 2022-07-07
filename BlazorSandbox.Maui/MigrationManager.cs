using Microsoft.EntityFrameworkCore;

namespace BlazorSandbox.Data
{
    public static class MigrationManager
    {
        public static MauiApp MigrateDatabase(this MauiApp app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<SpaceOperaDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        // Log errors
                        throw;
                    }
                }
            }

            return app;
        }
    }
}
