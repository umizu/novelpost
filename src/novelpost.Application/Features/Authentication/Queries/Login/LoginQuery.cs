using MediatR;
using novelpost.Application.Features.Authentication.Common;
using novelpost.Application.Errors.Common;
using OneOf;

namespace novelpost.Application.Features.Authentication.Queries.Login;

public record LoginQuery(
    string Username,
    string Password
) : IRequest<OneOf<AuthResult, IError>>;
