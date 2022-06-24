using MediatR;
using Exercises.Application.DTOs.ExerciseDTOs;

namespace Exercises.Application.Features.Exercises.Commands.DeleteExercise
{
    public class DeleteExerciseCommand : IRequest
    {
        public DeleteExerciseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
