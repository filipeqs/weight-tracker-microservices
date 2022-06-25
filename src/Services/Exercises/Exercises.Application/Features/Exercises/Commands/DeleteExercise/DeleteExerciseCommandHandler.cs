using MediatR;
using AutoMapper;
using Exercises.Application.Contracts.Persistance;
using Exercises.Application.Exceptions;
using Exercises.Domain.Entities;

namespace Exercises.Application.Features.Exercises.Commands.DeleteExercise
{
    public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand>
    {
        private readonly IMapper _mapper;
        private readonly IExerciseRepository _exerciseRepository;

        public DeleteExerciseCommandHandler(IMapper mapper, IExerciseRepository exerciseRepository)
        {
            _mapper = mapper;
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Unit> Handle(DeleteExerciseCommand request, CancellationToken cancellationToken)
        {
            var exerciseToDelete = await _exerciseRepository.GetByIdAsync(request.Id);
            if (exerciseToDelete == null)
                throw new NotFoundException(nameof(Exercise), request.Id);

            await _exerciseRepository.DeleteAsync(exerciseToDelete);

            return Unit.Value;
        }
    }
}
