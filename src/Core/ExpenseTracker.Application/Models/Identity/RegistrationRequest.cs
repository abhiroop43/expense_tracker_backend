namespace ExpenseTracker.Application.Models.Identity;

public class RegistrationRequest
{
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Password { get; set; }
}