using Domain.Commands;
using FluentValidation.Results;

namespace Domain.Extensions;

public static class ValidationExtentions
{
    public static void AddErrorToValidationResult(this BaseCustomerCommand request, string errorKey, string errorMessage)
    {
        request.ValidationResult.Errors.Add(new ValidationFailure(errorKey + " " + Guid.NewGuid().ToString(), errorMessage));
    }
}
