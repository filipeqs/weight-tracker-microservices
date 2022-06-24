using Exercises.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Exercises.Infrastructure.Persistance;
using Exercises.Application.Contracts.Persistance;

namespace Exercises.Infrastructure.Repositories
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(ExerciseContext dbContext)
            : base(dbContext)
        {
        }

        public async Task UpdateMuscleGroup(Exercise exercise, List<MuscleGroup> muscleGroup)
        {
            exercise?.MuscleGroups?.RemoveAll(q => true);
            exercise?.MuscleGroups?.AddRange(muscleGroup);
            
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Exercise>> GetExerciseByName(string name) =>
            await _dbContext.Exercises
                .Include(q => q.MuscleGroups)
                .Where(q => q.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();
    }
}
