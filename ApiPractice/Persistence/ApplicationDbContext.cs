using ApiPractice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Persistence;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}