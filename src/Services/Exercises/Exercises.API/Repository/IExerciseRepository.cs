using Exercises.API.Entities;

namespace Exercises.API.Repository
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetExercises();
        Task<Exercise> GetExerciseById(string id);
        Task<Exercise> GetExerciseByName(string name);
        Task CreateExercise(Exercise exercise);
        Task<bool> UpdateExercise(Exercise exercise);
        Task<bool> DeleteExercise(string id);
    }
}
