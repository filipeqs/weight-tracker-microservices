namespace Exercises.API.DTOs.ExerciseDTOs
{
    public class ExerciseCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageFile { get; set; }
    }
}
