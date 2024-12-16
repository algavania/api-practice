namespace ApiPractice.Domain.DTOs;

public class LoginResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Token { get; set; }
}