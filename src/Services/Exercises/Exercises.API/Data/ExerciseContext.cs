using Exercises.API.Entities;
using Exercises.API.Utilitities;
using MongoDB.Driver;

namespace Exercises.API.Data
{
    public class ExerciseContext : IExerciseContext
    {
        public ExerciseContext(IConfiguration configuration)
        {
            Exercises = MongoUtilities<Exercise>.GetCollection("Exercises", configuration);
            ExerciseContextSeed.SeedData(Exercises);

            MuscleGroups = MongoUtilities<MuscleGroup>.GetCollection("MuscleGroups", configuration);
            MuscleGroupContextSeed.SeedData(MuscleGroups);
        }

        public IMongoCollection<Exercise> Exercises { get; }
        public IMongoCollection<MuscleGroup> MuscleGroups { get; }
    }
}
