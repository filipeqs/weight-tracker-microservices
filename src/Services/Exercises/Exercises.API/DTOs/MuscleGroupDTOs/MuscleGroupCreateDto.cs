namespace Exercises.API.DTOs.MuscleGroupDTOs
{
    public class MuscleGroupCreateDto
    {
        public string Name { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
