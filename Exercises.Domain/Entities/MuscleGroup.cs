using Exercises.Domain.Common;

namespace Exercises.Domain.Entities
{
    public class MuscleGroup : EntityBase
    {
        public string Name { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}