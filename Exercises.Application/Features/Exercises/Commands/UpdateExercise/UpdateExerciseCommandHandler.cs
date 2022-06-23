using MediatR;
using AutoMapper;
using Exercises.Domain.Entities;
using Exercises.Application.DTOs.ExerciseDTOs;
using Exercises.Application.Contracts.Persistance;

namespace Exercises.Application.Features.Exercises.Commands.UpdateExercise
{
    public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, ExerciseDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;

        public UpdateExerciseCommandHandler(IMapper mapper, IExerciseRepository exerciseRepository)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
        }

        public async Task<ExerciseDetailsDto> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exerciseToUpdate = await _exerciseRepository.GetByIdAsync(request.ExerciseUpdateDto.Id);
            if (exerciseToUpdate == null)
            {
                throw new Exception();
            }

            _mapper.Map(request.ExerciseUpdateDto, exerciseToUpdate, typeof(ExerciseUpdateDto), typeof(Exercise));

            await _exerciseRepository.UpdateAsync(exerciseToUpdate);

            return _mapper.Map<ExerciseDetailsDto>(exerciseToUpdate);
        }
    }
}
