using MediatR;
using AutoMapper;
using Exercises.Application.DTOs.ExerciseDTOs;
using Exercises.Application.Contracts.Persistance;

namespace Exercises.Application.Features.Exercises.Queries.GetExerciseByName
{
    public class GetExerciseByNameQueryHandler : IRequestHandler<GetExerciseByNameQuery, List<ExerciseDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;

        public GetExerciseByNameQueryHandler(IMapper mapper, IExerciseRepository exerciseRepository)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
        }

        public async Task<List<ExerciseDetailsDto>> Handle(GetExerciseByNameQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetExerciseByName(request.Name);

            return _mapper.Map<List<ExerciseDetailsDto>>(exercise);
        }
    }
}
