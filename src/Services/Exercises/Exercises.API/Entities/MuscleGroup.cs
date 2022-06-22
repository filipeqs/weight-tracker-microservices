using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercises.API.Entities
{
    public class MuscleGroup
    {
        public MuscleGroup(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
