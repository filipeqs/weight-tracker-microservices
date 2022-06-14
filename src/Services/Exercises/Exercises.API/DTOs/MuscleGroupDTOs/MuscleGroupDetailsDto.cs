namespace Exercises.API.DTOs.MuscleGroupDTOs
{
    public class MuscleGroupDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
