using AutoMapper;
using Exercises.Application.DTOs.ExerciseDTOs;
using Exercises.Application.DTOs.MuscleGroupDTOs;
using Exercises.Domain.Entities;

namespace Exercises.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
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
