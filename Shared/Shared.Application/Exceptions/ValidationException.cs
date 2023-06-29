using FluentValidation.Results;

namespace Shared.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> ValidationErrors { get; set; }
    
    public ValidationException(IEnumerable<ValidationFailure> validationFailures)
    {
        ValidationErrors = 
            validationFailures
                .Select(validationFailure => validationFailure.ErrorMessage)
                .ToList();
    }
}
