using FluentValidation.Results;

namespace Exercises.Application.Exceptions
{
    public class ValidationErrorException : ApplicationException
    {
        public ValidationErrorException()
            : base("One or more validation failures have ocurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationErrorException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures.GroupBy(q => q.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; set; }
    }
}
