using novelpost.Application.Common.Interfaces.Persistence;
using novelpost.Domain.Models;

namespace novelpost.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _users.Find(u => u.Email == email);
    }

    public User? GetUserByUsername(string username)
    {
        return _users.Find(u => u.Username == username);
    }
}
