using MediatR;
using Exercises.Application.DTOs.ExerciseDTOs;

namespace Exercises.Application.Features.Exercises.Queries.GetExerciseByName
{
    public class GetExerciseByNameQuery : IRequest<List<ExerciseDetailsDto>>
    {
        public GetExerciseByNameQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
