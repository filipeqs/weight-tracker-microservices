using Exercises.API.Entities;

namespace Exercises.API.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetExercises();
        Task<Exercise?> GetExerciseById(int id);
        Task<IEnumerable<Exercise>> GetExerciseByName(string name);
        Task CreateExercise(Exercise exercise);
        Task<bool> UpdateExercise(Exercise exercise);
        Task<bool> DeleteExercise(int id);
        Task<bool> UpdateMuscleGroup(int id, List<MuscleGroup> muscleGroup);
    }
}
