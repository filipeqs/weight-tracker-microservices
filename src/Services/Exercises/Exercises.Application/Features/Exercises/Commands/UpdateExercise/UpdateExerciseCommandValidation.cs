using FluentValidation;

namespace Exercises.Application.Features.Exercises.Commands.UpdateExercise
{
    public class UpdateExerciseCommandValidation : AbstractValidator<UpdateExerciseCommand>
    {
        public UpdateExerciseCommandValidation()
        {
            RuleFor(e => e.ExerciseUpdateDto.Id)
               .NotEmpty().WithMessage("Id is required.")
               .NotNull();

            RuleFor(e => e.ExerciseUpdateDto.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull();

            RuleFor(e => e.ExerciseUpdateDto.Name)
                .NotEmpty().WithMessage("Description is required.")
                .NotNull();
        }
    }
}
