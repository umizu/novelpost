using Mapster;
using novelpost.Application.Features.Authentication.Commands.Register;
using novelpost.Application.Features.Authentication.Common;
using novelpost.Application.Features.Authentication.Queries.Login;
using novelpost.Contracts.Auth;

namespace novelpost.Api.Common.Mapping;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthResult, AuthResponse>()
            .MapWith(src => new AuthResponse(
                src.User.Id,
                src.User.FirstName,
                src.User.LastName,
                src.User.Username,
                src.User.Email,
                src.AccessToken,
                src.RefreshToken));

        config.NewConfig<RegisterRequest, RegisterCommand>()
            .MapWith(src => new RegisterCommand(
                src.FirstName,
                src.LastName,
                src.Username,
                src.Email,
                src.Password));

        config.NewConfig<LoginRequest, LoginQuery>()
            .MapWith(src => new LoginQuery(
                src.Username,
                src.Password));
    }
}
