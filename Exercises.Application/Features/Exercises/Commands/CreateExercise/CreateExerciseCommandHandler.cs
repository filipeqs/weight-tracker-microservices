using MediatR;
using AutoMapper;
using Exercises.Application.DTOs.ExerciseDTOs;
using Exercises.Application.Contracts.Persistance;
using Exercises.Domain.Entities;

namespace Exercises.Application.Features.Exercises.Commands.CreateExercise
{
    public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, ExerciseDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;

        public CreateExerciseCommandHandler(IMapper mapper, IExerciseRepository exerciseRepository)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
        }

        public async Task<ExerciseDetailsDto> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exerciseEntity = _mapper.Map<Exercise>(request.ExerciseCreateDto);
            var exercise = await _exerciseRepository.AddAsync(exerciseEntity);

            return _mapper.Map<ExerciseDetailsDto>(exercise);
        }
    }
}
