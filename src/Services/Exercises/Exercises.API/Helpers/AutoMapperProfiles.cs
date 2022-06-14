using AutoMapper;
using Exercises.API.DTOs.ExerciseDTOs;
using Exercises.API.DTOs.MuscleGroupDTOs;
using Exercises.API.Entities;

namespace Exercises.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Exercise, ExerciseDetailsDto>().ReverseMap();
            CreateMap<Exercise, ExerciseCreateDto>().ReverseMap();
            CreateMap<Exercise, ExerciseUpdateDto>().ReverseMap();

            CreateMap<MuscleGroup, MuscleGroupDetailsDto>().ReverseMap();
            CreateMap<MuscleGroup, MuscleGroupCreateDto>().ReverseMap();
            CreateMap<MuscleGroup, MuscleGroupUpdateDto>().ReverseMap();
        }
    }
}
