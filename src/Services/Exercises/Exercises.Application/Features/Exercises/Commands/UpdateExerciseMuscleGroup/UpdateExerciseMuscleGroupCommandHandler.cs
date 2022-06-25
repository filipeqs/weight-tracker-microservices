using MediatR;
using AutoMapper;
using Exercises.Domain.Entities;
using Exercises.Application.Contracts.Persistance;
using Exercises.Application.Exceptions;

namespace Exercises.Application.Features.Exercises.Commands.UpdateExerciseMuscleGroup
{
    public class UpdateExerciseMuscleGroupCommandHandler : IRequestHandler<UpdateExerciseMuscleGroupCommand>
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;

        public UpdateExerciseMuscleGroupCommandHandler(IMapper mapper, IExerciseRepository exerciseRepository)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Unit> Handle(UpdateExerciseMuscleGroupCommand request, CancellationToken cancellationToken)
        {
            var exerciseToUpdate = await _exerciseRepository.GetByIdAsync(request.Id);
            if (exerciseToUpdate == null)
                throw new NotFoundException(nameof(Exercise), request.Id);

            var muscleGroups = _mapper.Map<List<MuscleGroup>>(request.muscleGroupDetailsDto);

            await _exerciseRepository.UpdateMuscleGroup(exerciseToUpdate, muscleGroups);

            return Unit.Value;
        }
    }
}
