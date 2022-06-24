using Exercises.Domain.Entities;

namespace Exercises.Application.Contracts.Persistance
{
    public interface IExerciseRepository : IAsyncRepository<Exercise>
    {
        Task<IReadOnlyList<Exercise>> GetExerciseByName(string name);
        Task UpdateMuscleGroup(Exercise exercise, List<MuscleGroup> muscleGroup);
    }
}
