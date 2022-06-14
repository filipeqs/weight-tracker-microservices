using Exercises.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Exercises.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ExerciseContext>();
            context.Database.Migrate();

            return host;
        }
    }
}
