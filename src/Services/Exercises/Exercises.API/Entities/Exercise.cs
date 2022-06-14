using System.ComponentModel.DataAnnotations;

namespace Exercises.API.Entities
{
    public class Exercise
    {
        public Exercise(string name, string description, string? imageFile)
        {
            Name = name;
            Description = description;
            ImageFile = imageFile;
        }

        public Exercise(int id, string name, string description, string? imageFile)
            : this(name, description, imageFile)
        {
            Id = id;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ImageFile { get; set; }
        public List<MuscleGroup>? MuscleGroups { get; set; }
    }
}
