using FluentValidation.Results;

namespace Shared.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> ValidationErrors { get; set; }
    
    public ValidationException(IEnumerable<ValidationResult> validationResults)
    {
        ValidationErrors = 
            validationResults
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure is not null)
                .Select(validationFailure => validationFailure.ErrorMessage)
                .ToList();
    }
}
