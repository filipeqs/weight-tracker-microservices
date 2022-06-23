using MediatR;
using AutoMapper;
using Exercises.Application.DTOs.ExerciseDTOs;
using Exercises.Application.Contracts.Persistance;

namespace Exercises.Application.Features.Exercises.Queries.GetExercisesList
{
    public class GetExercisesListQueryHandler : IRequestHandler<GetExercisesListQuery, List<ExerciseDetailsDto>>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetExercisesListQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<List<ExerciseDetailsDto>> Handle(GetExercisesListQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _exerciseRepository.GetAllAsync();

            return _mapper.Map<List<ExerciseDetailsDto>>(exercises);
        }
    }
}
