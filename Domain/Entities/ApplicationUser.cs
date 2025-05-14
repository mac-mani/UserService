namespace Domain.Entities;

public class ApplicationUser
{
    public Guid UserId { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? PersonName { get; set; }
    public string? Gender { get; set; }
}