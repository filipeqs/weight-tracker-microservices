using FluentValidation;

namespace Exercises.Application.Features.Exercises.Commands.CreateExercise
{
    public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
    {
        public CreateExerciseCommandValidator()
        {
            RuleFor(e => e.ExerciseCreateDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .OverridePropertyName("Name");

            RuleFor(e => e.ExerciseCreateDto.Description)
                .NotEmpty().WithMessage("Description is required.")
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .OverridePropertyName("Description");
        }
    }
}
