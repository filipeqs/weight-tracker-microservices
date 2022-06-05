using Exercises.API.Data;
using Exercises.API.Entities;
using MongoDB.Driver;

namespace Exercises.API.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly IExerciseContext _context;

        public ExerciseRepository(IExerciseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetExercises() =>
            await _context.Exercises.Find(q => true).ToListAsync();

        public async Task<Exercise> GetExerciseById(string id) =>
            await _context.Exercises.Find(q => q.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Exercise>> GetExerciseByName(string name) =>
            await _context.Exercises
                .Find(q => q.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();

        public async Task CreateExercise(Exercise exercise) =>
            await _context.Exercises.InsertOneAsync(exercise);

        public async Task<bool> UpdateExercise(Exercise exercise)
        {
            var updatedResult = await _context.Exercises.ReplaceOneAsync(q => q.Id == exercise.Id, exercise);

            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteExercise(string id)
        {
            var deletedResult = await _context.Exercises.DeleteOneAsync(q => q.Id == id);

            return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
        }
    }
}
