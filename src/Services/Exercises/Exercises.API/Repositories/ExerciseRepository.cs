using Exercises.API.Data;
using Exercises.API.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Exercises.API.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseContext _context;

        public ExerciseRepository(ExerciseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetExercises() =>
            await _context.Exercises.ToListAsync();

        public async Task<Exercise?> GetExerciseById(int id) =>
            await _context.Exercises
                .Include(q => q.MuscleGroups)
                .FirstOrDefaultAsync(q => q.Id == id);

        public async Task<IEnumerable<Exercise>> GetExerciseByName(string name) =>
            await _context.Exercises
                .Include(q => q.MuscleGroups)
                .Where(q => q.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();

        public async Task CreateExercise(Exercise exercise)
        {
   
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateExercise(Exercise exercise)
        {
            _context.Entry(exercise).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteExercise(int id)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(q => q.Id == id);

            if (exercise == null)
                return false;

            _context.Exercises.Remove(exercise);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
