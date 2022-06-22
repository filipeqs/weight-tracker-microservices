using Exercises.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Domain.Entities
{
    public class Exercise : EntityBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ImageFile { get; set; }
        public List<MuscleGroup>? MuscleGroups { get; set; }
    }
}
