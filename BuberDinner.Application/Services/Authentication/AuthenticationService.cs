using System.Security.Principal;
using BuberDiner.Domain.Entities;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Application.Services.Authentication;

namespace BuberDiner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;


  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public AuthenticationResult Login(string Email, string Password)
  {
    // Validate user exists
    if (_userRepository.GetUserbyEmail(Email) is not User user)
    {
      throw new Exception("User with this email is not exsist");
    }
    // Validate password is correct
    if (user.Password != Password)
    {
      throw new Exception("Invalid password");
    }
    // Create JWT Token
    var token = _jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(user, token);
  }

  public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
  {
    // Check if user exists
    if (_userRepository.GetUserbyEmail(Email) is not null)
    {
      throw new Exception($"User with this email:{Email} is already exists");
    }
    // Create user (generate unique ID) and presist to DB
    var user = new User
    {
      FirstName = FirstName,
      LastName = LastName,
      Email = Email,
      Password = Password
    };
    _userRepository.Add(user);
    // Create JWT token for account
    var token = _jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(user, token);
  }
}