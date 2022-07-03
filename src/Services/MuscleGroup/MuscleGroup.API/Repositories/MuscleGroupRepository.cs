using Category.API.Entities;
using Category.API.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Category.API.Repositories
{
    public class MuscleGroupRepository : IMuscleGroupRepository
    {
        private MuscleGroupContext _context;

        public MuscleGroupRepository(MuscleGroupContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<MuscleGroup>> GetAllAsync() =>
            await _context.MuscleGroups.ToListAsync();

        public async Task<IReadOnlyList<MuscleGroup>> GetByNameAsync(string name) =>
            await _context.MuscleGroups.Where(q => q.Name.Contains(name)).ToListAsync();

        public async Task<MuscleGroup> GetByIdAsync(int id) =>
            await _context.MuscleGroups.FirstOrDefaultAsync(q => q.Id == id);

        public async Task AddAsync(MuscleGroup muscleGroup) =>
            await _context.MuscleGroups.AddAsync(muscleGroup);

        public void Update(MuscleGroup muscleGroup)
        {
            _context.Entry(muscleGroup).State = EntityState.Modified;
        }

        public void Delete(MuscleGroup muscleGroup) =>
            _context.MuscleGroups.Remove(muscleGroup);


        public async Task<bool> SaveChangesAsync() =>
            await _context.SaveChangesAsync() > 0;


    }
}
