using MuscleGroups.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MuscleGroups.API.Persistance
{
    public class MuscleGroupContext : DbContext
    {
        public MuscleGroupContext(DbContextOptions options) : base(options)
        {
        }

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
