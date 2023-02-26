using FluentValidation.Results;
using novelpost.Application.Errors.Common;
using OneOf;

namespace novelpost.Application.Extensions;

public static class GeneralExtensions
{
    public static ValidationError AsValidationError(this List<ValidationFailure> validationFailures)
    {
        var errors = new List<(string propertyName, string errorMessage)>();

        foreach (var error in validationFailures)
        {
            errors.Add((error.PropertyName, error.ErrorMessage));
        }

        return new ValidationError(errors);
    }
}
