using Exercises.Application.Contracts.Persistance;
using Exercises.Domain.Entities;
using Exercises.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Exercises.Infrastructure.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ExerciseContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> UpdateMuscleGroup(int id, List<MuscleGroup> muscleGroup)
        {
            var exercise = await _dbContext.Exercises.FirstOrDefaultAsync(q => q.Id == id);

            if (exercise == null)
                return false;

            exercise?.MuscleGroups?.RemoveAll(q => true);
            exercise?.MuscleGroups?.AddRange(muscleGroup);

            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
