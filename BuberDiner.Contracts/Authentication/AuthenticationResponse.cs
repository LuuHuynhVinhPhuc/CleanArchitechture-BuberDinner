namespace BuberDiner.Contracts.Authentication;

public record AuthenticationResponse(Guid id, string FirstName, string LastName, string Emai, string Token);