using Exercises.Domain.Entities;

namespace Exercises.Application.Contracts.Persistance
{
    public interface IExerciseRepository : IAsyncRepository<Exercise>
    {
        Task<bool> UpdateMuscleGroup(int id, List<MuscleGroup> muscleGroup);
    }
}
