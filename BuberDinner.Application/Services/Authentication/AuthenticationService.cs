using System.Security.Principal;
using BuberDiner.Application.Services.Authentication;
using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDiner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;

  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public AuthenticationResult Login(string Email, string Password)
  {
    return new AuthenticationResult(Guid.NewGuid(), "FirstName", "LastName", Email, "token");
  }

  public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
  {
    // Check if user exists
    // Create user (generate unique ID)
    // Create JWT token
    var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), FirstName, LastName);
    return new AuthenticationResult(Guid.NewGuid(), FirstName, LastName, Email, token);
  }
}