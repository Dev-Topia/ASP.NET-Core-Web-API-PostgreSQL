using Microsoft.EntityFrameworkCore;
using ComputerTopiaStoreApi.Models;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}