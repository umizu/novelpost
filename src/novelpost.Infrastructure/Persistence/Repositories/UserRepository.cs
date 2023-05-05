using Microsoft.EntityFrameworkCore;
using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Domain.Models;

namespace novelpost.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDataContext _ctx;

    public UserRepository(IDataContext ctx)
    {
        _ctx = ctx;
    }

    public async Task AddAsync(User user)
    {
        await _ctx.Users.AddAsync(user);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _ctx.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public Task<User?> GetUserByUsernameAsync(string username)
    {
        return _ctx.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
}
