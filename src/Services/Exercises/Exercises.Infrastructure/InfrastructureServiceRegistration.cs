using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Exercises.Infrastructure.Persistance;
using Exercises.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Exercises.Application.Contracts.Persistance;

namespace Exercises.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ExerciseConnectionString");
            services.AddDbContext<ExerciseContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IExerciseRepository, ExerciseRepository>();

            return services;
        }
    }
}
