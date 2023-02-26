using MediatR;
using novelpost.Application.Authentication.Common;
using novelpost.Application.Errors.Common;
using OneOf;

namespace novelpost.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Username,
    string Password
) : IRequest<OneOf<AuthResult, IError>>;
