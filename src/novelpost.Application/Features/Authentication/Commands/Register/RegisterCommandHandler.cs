using MediatR;
using novelpost.Application.Common.Interfaces.Authentication;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Domain.Models;
using OneOf;
using novelpost.Application.Errors.Common;
using novelpost.Application.Errors.Auth;
using novelpost.Application.Features.Authentication.Common;

namespace novelpost.Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, OneOf<AuthResult, IError>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepo;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepo)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepo = userRepo;
    }

    public async Task<OneOf<AuthResult, IError>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepo.GetUserByEmail(command.Email) is not null)
            return new DuplicateEmailError();
        if (_userRepo.GetUserByUsername(command.Username) is not null)
            return new DuplicateUsernameError();

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Username = command.Username,
            Email = command.Email,
            Password = command.Password
        };

        _userRepo.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token);
    }
}
