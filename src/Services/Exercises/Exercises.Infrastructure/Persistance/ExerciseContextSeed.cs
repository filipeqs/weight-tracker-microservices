using Exercises.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Exercises.Infrastructure.Persistance
{
    public class ExerciseContextSeed
    {
        public static async Task SeedAsync(ExerciseContext context, ILogger<ExerciseContextSeed> logger)
        {
            if (!context.MuscleGroups.Any())
            {
                var muscleGroups = GetPreconfiguredMuscleGroups();
                context.MuscleGroups.AddRange(muscleGroups);
                await context.SaveChangesAsync();

                logger.LogInformation($"Seed database associated with context {typeof(MuscleGroup).Name}");
            }

            if (!context.Exercises.Any())
            {
                var exercises = GetPreconfiguredExercises(context);
                context.Exercises.AddRange(exercises);
                await context.SaveChangesAsync();

                logger.LogInformation($"Seed database associated with context {typeof(ExerciseContext).Name}");
            }
        }

        private static IEnumerable<Exercise> GetPreconfiguredExercises(ExerciseContext context)
        {
            var chest = context.MuscleGroups.FirstOrDefault(q => q.Name == "Chest");
            var legs = context.MuscleGroups.FirstOrDefault(q => q.Name == "Legs");
            return new List<Exercise>
            {
                new Exercise()
                {
                    Name = "Bench Press",
                    Description = "Bench Press",
                    MuscleGroups = new List<MuscleGroup>{ chest }
                },
                new Exercise()
                {
                    Name = "Squat",
                    Description = "Squat",
                    MuscleGroups = new List<MuscleGroup>{ legs }
                }
            };
        }

        private static IEnumerable<MuscleGroup> GetPreconfiguredMuscleGroups()
        {
            return new List<MuscleGroup>
            {
                new MuscleGroup
                {
                    Name = "Chest"
                },
                
                new MuscleGroup
                {
                    Name = "Legs"
                }
            };
        }
    }
}
