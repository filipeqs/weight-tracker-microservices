using Exercises.Application.DTOs.ExerciseDTOs;
using MediatR;

namespace Exercises.Application.Features.Exercises.Commands.CreateExercise
{
    public class CreateExerciseCommand : IRequest<ExerciseDetailsDto>
    {
        public CreateExerciseCommand(ExerciseCreateDto exerciseCreateDto)
        {
            ExerciseCreateDto = exerciseCreateDto;
        }

        public ExerciseCreateDto ExerciseCreateDto { get; set; }
    }
}
