using MediatR;
using AutoMapper;
using Exercises.Application.Contracts.Persistance;

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
            {
                throw new Exception();
            }

            await _exerciseRepository.DeleteAsync(exerciseToDelete);

            return Unit.Value;
        }
    }
}
