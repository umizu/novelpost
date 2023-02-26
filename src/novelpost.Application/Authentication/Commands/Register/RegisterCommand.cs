using MediatR;
using novelpost.Application.Authentication.Common;
using novelpost.Application.Errors.Common;
using OneOf;

namespace novelpost.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Password) : IRequest<OneOf<AuthResult, IError>>;
