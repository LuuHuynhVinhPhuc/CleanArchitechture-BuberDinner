using BuberDiner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
  User? GetUserbyEmail(string email);
  void Add(User user);
}