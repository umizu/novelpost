using MediatR;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Domain.Models;
using OneOf;
using novelpost.Application.Errors.Common;
using novelpost.Application.Errors.Auth;
using novelpost.Application.Features.Authentication.Common;
using novelpost.Application.Common.Interfaces.Auth;

namespace novelpost.Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, OneOf<AuthResult, IError>>
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepo;
    private readonly IUnitOfWork _uow;

    public RegisterCommandHandler(ITokenService tokenService, IUserRepository userRepo, IUnitOfWork uow)
    {
        _tokenService = tokenService;
        _userRepo = userRepo;
        _uow = uow;
    }

    public async Task<OneOf<AuthResult, IError>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepo.GetUserByEmailAsync(command.Email) is not null)
            return new DuplicateEmailError();
        if (await _userRepo.GetUserByUsernameAsync(command.Username) is not null)
            return new DuplicateUsernameError();

        var id = Guid.NewGuid();
        var user = new User
        {
            Id = id,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Username = command.Username,
            Email = command.Email,
            Password = command.Password
        };

        await _userRepo.AddAsync(user);

        var accessToken = _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateAndSetRefreshToken();

        await _uow.SaveChangesAsync(cancellationToken);

        return new AuthResult(
            user,
            accessToken,
            refreshToken.Token);
    }
}
