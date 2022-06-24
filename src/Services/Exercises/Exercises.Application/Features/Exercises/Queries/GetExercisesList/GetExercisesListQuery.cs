using Exercises.Application.DTOs.ExerciseDTOs;
using MediatR;

namespace Exercises.Application.Features.Exercises.Queries.GetExercisesList
{
    public class GetExercisesListQuery : IRequest<List<ExerciseDetailsDto>>
    {
    }
}
