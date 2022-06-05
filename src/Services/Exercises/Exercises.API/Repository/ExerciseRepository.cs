using Exercises.API.Data;
using Exercises.API.Entities;
using MongoDB.Driver;

namespace Exercises.API.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseContext _context;

        public ExerciseRepository(ExerciseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetExercises() =>
            await _context.Exercises.Find(p => true).ToListAsync();

        public async Task<Exercise> GetExerciseById(string id) =>
            await _context.Exercises.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<Exercise> GetExerciseByName(string name) =>
            await _context.Exercises.Find(p => p.Name == name).FirstOrDefaultAsync();

        public async Task CreateExercise(Exercise exercise) =>
            await _context.Exercises.InsertOneAsync(exercise);

        public async Task<bool> UpdateExercise(Exercise exercise)
        {
            var updatedResult = await _context.Exercises.ReplaceOneAsync(p => p.Id == exercise.Id, exercise);

            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteExercise(string id)
        {
            var deletedResult = await _context.Exercises.DeleteOneAsync(p => p.Id == id);

            return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
        }
    }
}
