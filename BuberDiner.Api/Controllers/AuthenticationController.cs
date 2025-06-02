using BuberDiner.Application.Services.Authentication;
using BuberDiner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDiner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
  private readonly IAuthenticationService _authenticationService;

  public AuthenticationController(IAuthenticationService authenticationService)
  {
    _authenticationService = authenticationService;
  }

  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    var authRes = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

    var res = new AuthenticationResponse(authRes.user.ID, authRes.user.FirstName, authRes.user.LastName, authRes.user.Email, authRes.Token
    );
    return Ok(res);
  }

  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    var authRes = _authenticationService.Login(request.Email, request.Password);

    var res = new AuthenticationResponse(authRes.user.ID, authRes.user.FirstName, authRes.user.LastName, authRes.user.Email, authRes.Token
    );

    return Ok(res);
  }
}