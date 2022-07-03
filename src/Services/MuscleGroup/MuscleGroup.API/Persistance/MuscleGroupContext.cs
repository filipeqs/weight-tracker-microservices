using Category.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Category.API.Persistance
{
    public class MuscleGroupContext : DbContext
    {
        public MuscleGroupContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MuscleGroup> MuscleGroups { get; set; }
    }
}
