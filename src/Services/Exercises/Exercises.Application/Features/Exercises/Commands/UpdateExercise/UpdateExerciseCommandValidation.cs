using FluentValidation;

namespace Exercises.Application.Features.Exercises.Commands.UpdateExercise
{
    public class UpdateExerciseCommandValidation : AbstractValidator<UpdateExerciseCommand>
    {
        public UpdateExerciseCommandValidation()
        {
            RuleFor(e => e.ExerciseUpdateDto.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .OverridePropertyName("Id");

            RuleFor(e => e.ExerciseUpdateDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .OverridePropertyName("Name");

            RuleFor(e => e.ExerciseUpdateDto.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} must not be empty.")
                .OverridePropertyName("Description");
        }
    }
}
