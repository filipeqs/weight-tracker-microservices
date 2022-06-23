using MediatR;
using Exercises.Application.DTOs.ExerciseDTOs;

namespace Exercises.Application.Features.Exercises.Queries.GetExerciseById
{
    public class GetExerciseByIdQuery : IRequest<ExerciseDetailsDto>
    {
        public GetExerciseByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
