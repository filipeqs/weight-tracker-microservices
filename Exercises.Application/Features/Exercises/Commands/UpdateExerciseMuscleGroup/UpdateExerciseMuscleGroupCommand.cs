using Exercises.Application.DTOs.MuscleGroupDTOs;
using MediatR;

namespace Exercises.Application.Features.Exercises.Commands.UpdateExerciseMuscleGroup
{
    public class UpdateExerciseMuscleGroupCommand : IRequest
    {
        public UpdateExerciseMuscleGroupCommand(int id, List<MuscleGroupCreateDto> muscleGroupDetailsDto)
        {
            Id = id;
            this.muscleGroupDetailsDto = muscleGroupDetailsDto;
        }

        public int Id { get; set; }
        public List<MuscleGroupCreateDto> muscleGroupDetailsDto;
    }
}
