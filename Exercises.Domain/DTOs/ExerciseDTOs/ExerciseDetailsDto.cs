namespace Exercises.Domain.DTOs.ExerciseDTOs
{
    internal class ExerciseDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageFile { get; set; }
        public List<MuscleGroupDetailsDto>? MuscleGroups { get; set; }
    }
}
