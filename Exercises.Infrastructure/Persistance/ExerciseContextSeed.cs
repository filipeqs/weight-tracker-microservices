using Exercises.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Exercises.Infrastructure.Persistance
{
    public class ExerciseContextSeed
    {
        public static async Task SeedAsync(ExerciseContext context, ILogger<ExerciseContextSeed> logger)
        {
            if (!context.Exercises.Any())
            {
                var exercises = GetPreconfiguredExercises();
                context.Exercises.AddRange(exercises);
                await context.SaveChangesAsync();

                logger.LogInformation($"Seed database associated with context {typeof(ExerciseContext).Name}");
            }
        }

        private static IEnumerable<Exercise> GetPreconfiguredExercises()
        {
            return new List<Exercise>
            {
                new Exercise()
                {
                    Name = "Bench Press",
                    Description = "Bench Press"
                }
            };
        }
    }
}
