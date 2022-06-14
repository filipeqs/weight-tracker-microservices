namespace Exercises.API.DTOs.MuscleGroupDTOs
{
    public class MuscleGroupUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
