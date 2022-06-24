using MediatR;
using AutoMapper;
using Exercises.Application.DTOs.ExerciseDTOs;
using Exercises.Application.Contracts.Persistance;

namespace Exercises.Application.Features.Exercises.Queries.GetExerciseById
{
    public class GetExerciseByIdQueryHandler : IRequestHandler<GetExerciseByIdQuery, ExerciseDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;

        public GetExerciseByIdQueryHandler(IMapper mapper, IExerciseRepository exerciseRepository)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
        }

        public async Task<ExerciseDetailsDto> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.Id);

            return _mapper.Map<ExerciseDetailsDto>(exercise);
        }
    }
}
