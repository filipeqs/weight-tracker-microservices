using FluentValidation;

namespace Exercises.Application.Features.Exercises.Commands.CreateExercise
{
    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        public CreateExerciseCommandValidator()
        {
            RuleFor(e => e.ExerciseCreateDto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull();

            RuleFor(e => e.ExerciseCreateDto.Name)
                .NotEmpty().WithMessage("Description is required.")
                .NotNull();
        }
    }
}
