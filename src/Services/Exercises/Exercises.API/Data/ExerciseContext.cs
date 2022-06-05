using Exercises.API.Entities;
using MongoDB.Driver;

namespace Exercises.API.Data
{
    public class ExerciseContext : IExerciseContext
    {
        public ExerciseContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Exercises = database.GetCollection<Exercise>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            ExerciseContextSeed.SeedData(Exercises);
        }

        public IMongoCollection<Exercise> Exercises { get; }
    }
}
