namespace novelpost.Application.Errors.Common;

public interface IValidationError : IError
{
    List<(string propertyName, string errorMessage)> Errors { get; set; }
}
