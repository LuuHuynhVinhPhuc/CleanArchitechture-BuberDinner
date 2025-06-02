namespace BuberDiner.Domain.Entities;

public class User
{
  public Guid ID { get; set; } = Guid.NewGuid();
  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
}