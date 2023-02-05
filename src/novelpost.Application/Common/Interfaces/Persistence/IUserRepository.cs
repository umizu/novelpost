using novelpost.Domain.Models;

namespace novelpost.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    User? GetUserByUsername(string username);
    void Add(User user);
}
