using MuscleGroups.API.Entities;

namespace MuscleGroups.API.Repositories
{
    public interface IMuscleGroupRepository
    {
        Task<MuscleGroup> GetByIdAsync(int id);
        Task<IReadOnlyList<MuscleGroup>> GetAllAsync();
        Task<IReadOnlyList<MuscleGroup>> GetByNameAsync(string name);
        Task AddAsync(MuscleGroup muscleGroup);
        void Update(MuscleGroup muscleGroup);
        void Delete(MuscleGroup muscleGroup);
        Task<bool> SaveChangesAsync();
    }
}
