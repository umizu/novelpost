using MediatR;
using novelpost.Application.Errors.Common;
using novelpost.Application.Features.Authentication.Common;
using OneOf;

namespace novelpost.Application.Features.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Password) : IRequest<OneOf<AuthResult, IError>>;
