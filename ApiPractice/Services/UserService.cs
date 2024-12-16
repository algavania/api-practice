using ApiPractice.Domain.DTOs;
using ApiPractice.Persistence;

namespace ApiPractice.Services;

public class UserService(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    public async Task<UserResponse> UpdateUserAsync(int userId, string name, string email)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) throw new Exception("User not found");
        user.Name = name;
        user.Email = email;
        await _context.SaveChangesAsync();
        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) throw new Exception("User not found");
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}