using Exercises.API.Entities;
using MongoDB.Driver;

namespace Exercises.API.Data
{
    public interface IExerciseContext
    {
        IMongoCollection<Exercise> Exercises { get; }
        IMongoCollection<MuscleGroup> MuscleGroups { get; }
    }
}
