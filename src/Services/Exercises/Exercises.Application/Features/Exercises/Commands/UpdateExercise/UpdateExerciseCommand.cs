using MediatR;
using Exercises.Application.DTOs.ExerciseDTOs;

namespace Exercises.Application.Features.Exercises.Commands.UpdateExercise
{
    public class UpdateExerciseCommand : IRequest<ExerciseDetailsDto>
    {
        public UpdateExerciseCommand(ExerciseUpdateDto exerciseUpdateDto)
        {
            ExerciseUpdateDto = exerciseUpdateDto;
        }

        public ExerciseUpdateDto ExerciseUpdateDto { get; set; }
    }
}
