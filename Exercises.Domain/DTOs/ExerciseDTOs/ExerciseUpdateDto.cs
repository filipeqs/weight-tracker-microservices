﻿namespace Exercises.Domain.DTOs.ExerciseDTOs
{
    public class ExerciseUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageFile { get; set; }
    }
}
