using FluentValidation.Results;

namespace Ordering.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public Dictionary<string, List<string>> Errors { get; }
        public ValidationException() : base("One or more validation error(s) occured.")
        {
            Errors = new Dictionary<string, List<string>>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(f => f.Key, f => f.ToList());
        }
    }
}
