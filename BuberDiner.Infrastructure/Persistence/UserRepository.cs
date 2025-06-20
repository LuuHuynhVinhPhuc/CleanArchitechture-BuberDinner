using BuberDiner.Domain.Entities;
using BuberDinner.Application.Common.Interfaces.Persistance;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{

  private static readonly List<User> _users = new();
  public void Add(User user)
  {
    _users.Add(user);
  }

  public User? GetUserbyEmail(string email)
  {
    return _users.SingleOrDefault(u => u.Email == email);
  }
}