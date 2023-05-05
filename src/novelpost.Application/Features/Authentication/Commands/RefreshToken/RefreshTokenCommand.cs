using MediatR;
using novelpost.Application.Errors.Common;
using novelpost.Application.Features.Authentication.Common;
using OneOf;

namespace novelpost.Application.Features.Authentication.Commands.RefreshToken;

public record RefreshTokenCommand() : IRequest<OneOf<AuthResult, IError>>;
