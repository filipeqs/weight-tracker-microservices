using Exercises.Domain.Common;
using Exercises.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercises.Infrastructure.Persistance
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "filipe";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "filipe";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
