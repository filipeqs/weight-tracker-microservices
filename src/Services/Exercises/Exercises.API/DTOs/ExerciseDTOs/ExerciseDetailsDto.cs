using Exercises.API.DTOs.MuscleGroupDTOs;

namespace Exercises.API.DTOs.ExerciseDTOs
{
    public class ExerciseDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageFile { get; set; }
        public List<MuscleGroupDetailsDto>? MuscleGroups { get; set; }
    }
}
